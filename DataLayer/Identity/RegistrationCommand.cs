using MediatR;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.Identity
{
	public class RegistrationCommand : IRequest<UserModel>
	{
		public string DisplayName { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}
}