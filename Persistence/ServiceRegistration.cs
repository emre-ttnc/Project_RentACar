using Application.Repositories.BrandRepositories;
using Application.Repositories.ModelRepositories;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.BrandRepositories;
using Persistence.Repositories.ModelRepositories;
using Persistence.Services;

namespace Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<RentACarDbContext>(options =>
        {
            options.UseNpgsql(Configurations.ConnectionString);
        });

        services.AddScoped<IBrandReadRepository, BrandReadRepository>();
        services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
        services.AddScoped<IModelReadRepository, ModelReadRepository>();
        services.AddScoped<IModelWriteRepository, ModelWriteRepository>();

        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IModelService, ModelService>();

        return services;
    }
}