using Microsoft.Extensions.Configuration;

namespace Persistence;

public static class Configurations
{
    public static string ConnectionString {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RentACar.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}