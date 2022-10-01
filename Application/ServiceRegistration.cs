using Application.Features.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration));
        services.AddScoped<BrandBusinessRules>();

        return services;
    }
}