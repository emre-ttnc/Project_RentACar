using Application.Services;
using MediatR;

namespace Application.Features.Commands.BrandCommands;

public class CreateBrandCommand: IRequest<bool>
{
    public string BrandName { get; set; } = string.Empty;

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
    {
        private readonly IBrandService _brandService;

        public CreateBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken) =>
            await _brandService.AddNewBrandAsync(request.BrandName);
    }
}