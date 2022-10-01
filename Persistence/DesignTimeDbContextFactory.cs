using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Contexts;

namespace Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RentACarDbContext>
{
    public RentACarDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<RentACarDbContext> builder = new ();
        builder.UseNpgsql(Configurations.ConnectionString);

        return new(builder.Options);
    }
}