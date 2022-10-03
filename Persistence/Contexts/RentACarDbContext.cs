using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class RentACarDbContext : DbContext
{
    public RentACarDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Brand>? Brands { get; set; }
    public DbSet<Model>? Models { get; set; }
    public DbSet<Car>? Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(brand =>
        {
            brand.ToTable("Brands").HasKey(brand => brand.Id);
            brand.Property(brand => brand.Id).HasColumnName("Id");
            brand.Property(brand => brand.BrandName).HasColumnName("BrandName");
            brand.HasMany(brand => brand.Models).WithOne(model => model.Brand);
        });

        modelBuilder.Entity<Model>(model =>
        {
            model.ToTable("Models").HasKey(model => model.Id);
            model.Property(model => model.Id).HasColumnName("Id");
            model.Property(model => model.ModelName).HasColumnName("ModelName");
            model.HasOne(model => model.Brand).WithMany(brand => brand.Models).HasForeignKey(model => model.BrandId);
        });

        modelBuilder.Entity<Car>(car =>
        {
            car.ToTable("Cars").HasKey(car => car.Id);
            car.Property(car => car.Id).HasColumnName("Id");
            car.Property(car => car.ImageURL).HasColumnName("ImageURL");
            car.Property(car => car.ModelYear).HasColumnName("ModelYear");
            car.Property(car => car.CarState).HasColumnName("CarState");
            car.Property(car => car.DailyPrice).HasColumnName("DailyPrice");
        });

        Brand[] brands = {
            new() { Id = Guid.NewGuid(), BrandName = "BMW" },
            new() { Id = Guid.NewGuid(), BrandName = "Mercedes-Benz" }
        };

        Model[] models = {
            new() { Id = Guid.NewGuid(), BrandId = brands[0].Id, ModelName = "Series 4" },
            new() { Id = Guid.NewGuid(), BrandId = brands[0].Id, ModelName = "Series 3" },
            new() { Id = Guid.NewGuid(), BrandId = brands[1].Id, ModelName = "A 180" }
        };

        Car[] cars = {
            new() { Id = Guid.NewGuid(), ModelId = models[0].Id, ModelYear = 2020, DailyPrice = 1000, ImageURL = " ", CarState = Domain.Enums.CarState.Available },
            new() { Id = Guid.NewGuid(), ModelId = models[1].Id, ModelYear = 2021, DailyPrice = 800, ImageURL = " ", CarState = Domain.Enums.CarState.Available },
            new() { Id = Guid.NewGuid(), ModelId = models[2].Id, ModelYear = 2022, DailyPrice = 800, ImageURL = " ", CarState = Domain.Enums.CarState.Available }
        };

        modelBuilder.Entity<Brand>().HasData(brands);
        modelBuilder.Entity<Model>().HasData(models);
        modelBuilder.Entity<Car>().HasData(cars);
    }
}