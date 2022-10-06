using Application.Repositories.BrandRepositories;
using Application.Repositories.ModelRepositories;
using Application.Repositories.UserRepository.cs;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.BrandRepositories;
using Persistence.Repositories.ModelRepositories;
using Persistence.Repositories.UserRepositories;
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
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();

        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}