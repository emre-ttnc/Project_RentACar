using Application.Services;
using MediatR;

namespace Application.Features.Commands.ModelCommands;

public class CreateModelCommand : IRequest<bool>
{
    public string ModelName { get; set; } = string.Empty;
    public string BrandId { get; set; } = string.Empty;

    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, bool>
    {
        private readonly IModelService _modelService;

        public CreateModelCommandHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public async Task<bool> Handle(CreateModelCommand request, CancellationToken cancellationToken) =>
            await _modelService.AddNewModelAsync(modelName: request.ModelName, brandId: request.BrandId);

    }
}