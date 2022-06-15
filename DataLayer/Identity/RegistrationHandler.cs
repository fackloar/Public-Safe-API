using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Rest;
using Safe_Development.DataLayer;
using Safe_Development.DataLayer.Identity;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.Identity
{
	public class RegistrationHandler : IRequestHandler<RegistrationCommand, UserModel>
	{
		private readonly UserManager<User> _userManager;
		private readonly IJwtGenerator _jwtGenerator;
		private readonly DataContext _context;

		public RegistrationHandler(DataContext context, UserManager<User> userManager, IJwtGenerator jwtGenerator)
		{
			_context = context;
			_userManager = userManager;
			_jwtGenerator = jwtGenerator;
		}

		public async Task<UserModel> Handle(RegistrationCommand request, CancellationToken cancellationToken)
		{
			if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
			{
				throw new RestException(HttpStatusCode.BadRequest.ToString() + "Email already exist" );
			}

			if (await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
			{
				throw new RestException(HttpStatusCode.BadRequest.ToString() + "UserName already exist" );
			}

			var user = new User
							{
								DisplayName = request.DisplayName,
								Email = request.Email,
								UserName = request.UserName
							};

			var result = await _userManager.CreateAsync(user, request.Password);

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

			throw new Exception("Client creation failed");
		}
	}

    internal record NewRecord(string UserName);
}