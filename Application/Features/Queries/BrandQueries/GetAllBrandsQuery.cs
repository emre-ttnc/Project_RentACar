using Application.Models;
using Application.Services;
using MediatR;

namespace Application.Features.Queries.BrandQueries;

public class GetAllBrandsQuery : IRequest<BrandListModel>
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, BrandListModel>
    {
        private readonly IBrandService _brandService;

        public GetAllBrandsQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<BrandListModel> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken) =>
            await _brandService.GetAllBrandsAsync(request.Page, request.PageSize);
    }
}