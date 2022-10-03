using Application.Models;
using Application.Services;
using MediatR;

namespace Application.Features.Queries.ModelQueries;

public class GetAllModelsQuery : IRequest<ModelListModel>
{
    public class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, ModelListModel>
    {
        private readonly IModelService _modelService;

        public GetAllModelsQueryHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public async Task<ModelListModel> Handle(GetAllModelsQuery request, CancellationToken cancellationToken) =>
            await _modelService.GetAllAsync();
    }
}