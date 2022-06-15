using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Safe_Development.DataLayer.Models;
using Safe_Development.Identity;

namespace Safe_Development.Controllers
{
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> LoginAsync(LoginQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("registration")]
        public async Task<ActionResult<UserModel>> RegistrationAsync(RegistrationCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
