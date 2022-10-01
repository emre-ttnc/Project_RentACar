using Application.Services;
using MediatR;

namespace Application.Features.Commands.BrandCommands;

public class RemoveBrandCommand : IRequest<bool>
{
    public string BrandId { get; set; } = string.Empty;

    public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommand, bool>
    {
        private readonly IBrandService _brandService;

        public RemoveBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public Task<bool> Handle(RemoveBrandCommand request, CancellationToken cancellationToken) =>
            _brandService.RemoveBrand(request.BrandId);

    }
}