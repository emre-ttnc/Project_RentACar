using Application.Features.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request) =>
            Ok(await _mediator.Send(request));
    }
}
