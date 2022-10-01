using Application.Features.Commands.BrandCommands;
using FluentValidation;

namespace Application.Features.Validators.BrandValidators;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(brand => brand.BrandName).NotEmpty().NotNull();
        RuleFor(brand => brand.BrandName).MinimumLength(2);
        RuleFor(brand => brand.BrandName).MaximumLength(16);
    }
}