using MediatR;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.Identity
{
	public class LoginQuery : IRequest<UserModel>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
