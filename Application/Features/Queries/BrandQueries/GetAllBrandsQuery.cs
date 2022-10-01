using Application.Models;
using Application.Services;
using MediatR;

namespace Application.Features.Queries.BrandQueries;

public class GetAllBrandsQuery : IRequest<BrandListModel>
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, BrandListModel>
    {
        private readonly IBrandService _brandService;

        public GetAllBrandsQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<BrandListModel> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken) =>
            await _brandService.GetAll();
    }
}