using Application.DTOs.AuthDTOs;
using Application.Services;
using MediatR;

namespace Application.Features.Commands.AuthCommands;

public class LoginCommand : IRequest<AccessToken>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken) =>
            await _authService.LoginAsync(email: request.Email, password: request.Password);

    }
}