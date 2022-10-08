using Application.DynamicQuery;
using Application.Models;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.BrandQueries;

public class GetAllBrandsByDynamicQuery : IRequest<BrandListPageableModel>
{
    public Dynamic Dynamic { get; set; } = new();
    public int Page { get; set; }
    public int Size { get; set; }


    public class GetAllBrandsByDynamicQueryHandler : IRequestHandler<GetAllBrandsByDynamicQuery, BrandListPageableModel>
    {
        private readonly IBrandService _brandService;

        public GetAllBrandsByDynamicQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<BrandListPageableModel> Handle(GetAllBrandsByDynamicQuery request, CancellationToken cancellationToken) =>
            await _brandService.GetAllByDynamic(dynamic: request.Dynamic, page: request.Page, size: request.Size, include: q => q.Include(b => b.Models));
    }
}