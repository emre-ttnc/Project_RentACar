using Application.Services;
using MediatR;

namespace Application.Features.Commands.ModelCommands;

public class UpdateModelCommand : IRequest<bool>
{
    public string Id { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;

    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, bool>
    {
        private readonly IModelService _modelService;

        public UpdateModelCommandHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public async Task<bool> Handle(UpdateModelCommand request, CancellationToken cancellationToken) =>
            await _modelService.UpdateModelAsync( modelId: request.Id, modelName: request.ModelName);
    }
}