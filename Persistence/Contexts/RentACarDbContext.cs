using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class RentACarDbContext : DbContext
{
    public RentACarDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Brand>? Brands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(brand =>
        {
            brand.ToTable("Brands").HasKey(brand => brand.Id);
            brand.Property(brand => brand.Id).HasColumnName("Id");
            brand.Property(brand => brand.BrandName).HasColumnName("BrandName");
        });

        //Brand Seed Datas
        modelBuilder.Entity<Brand>().HasData(
            new Brand(Guid.NewGuid(), "BMW"),
            new Brand(Guid.NewGuid(), "Mercedes-Benz")
            );
    }
}