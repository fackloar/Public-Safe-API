using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Rest;
using Safe_Development.DataLayer.Identity;
using Safe_Development.DataLayer.Models;
using System.Net;

namespace Safe_Development.Identity
{
	public class LoginHandler : IRequestHandler<LoginQuery, UserModel>
	{
		private readonly UserManager<User> _userManager;

		private readonly SignInManager<User> _signInManager;
		
		private readonly IJwtGenerator _jwtGenerator;

		public LoginHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtGenerator = jwtGenerator;
		}

		public async Task<UserModel> Handle(LoginQuery request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new RestException(HttpStatusCode.Unauthorized.ToString());
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (result.Succeeded)
			{
				return new UserModel
				{
					DisplayName = user.DisplayName,
					Token = _jwtGenerator.CreateToken(user),
					UserName = user.UserName,
					Image = null
				};
			}

			throw new RestException(HttpStatusCode.Unauthorized.ToString());
		}
	}
}
