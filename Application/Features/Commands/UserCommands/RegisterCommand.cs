using Application.Services;
using MediatR;

namespace Application.Features.Commands.UserCommands;

public class RegisterCommand : IRequest<bool>
{

    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IUserService _userService;

        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken) =>
            await _userService.RegisterAsync(request.Email, request.Password, request.FirstName, request.LastName);
    }
}