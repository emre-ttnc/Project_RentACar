using Application.Services;
using MediatR;

namespace Application.Features.Commands.BrandCommands;

public class UpdateBrandCommand : IRequest<bool>
{
    public string BrandId { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IBrandService _brandService;

        public UpdateBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken) =>
            await _brandService.UpdateBrand(request.BrandId, request.BrandName);
    }
}