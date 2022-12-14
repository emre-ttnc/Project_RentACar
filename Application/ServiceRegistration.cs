using Application.Features.Commands.BrandCommands;
using Application.Features.Rules;
using Application.Features.Validators.BrandValidators;
using Application.Helpers;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));

        //it is not recommended
        services.AddFluentValidationAutoValidation();

        //services.AddValidatorsFromAssemblyContaining<CreateBrandCommandValidator>();
        services.AddScoped<IValidator<CreateBrandCommand>, CreateBrandCommandValidator>(); //### Manual validation.

        services.AddScoped<JWTTokenHelper>();

        services.AddScoped<BrandBusinessRules>();
        services.AddScoped<ModelBusinessRules>();
        services.AddScoped<UserBusinessRules>();

        return services;
    }
}