using Application.Services;
using MediatR;

namespace Application.Features.Commands.ModelCommands;

public class RemoveModelCommand : IRequest<bool>
{
    public string Id { get; set; } = string.Empty;

    public class RemoveModelCommandHandler : IRequestHandler<RemoveModelCommand, bool>
    {
        private readonly IModelService _modelService;

        public RemoveModelCommandHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public async Task<bool> Handle(RemoveModelCommand request, CancellationToken cancellationToken) =>
            await _modelService.RemoveModelAsync(request.Id);
    }
}