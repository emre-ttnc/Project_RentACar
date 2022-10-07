using Application.Features.Commands.AuthCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand request) =>
        Ok(await _mediator.Send(request));
}
