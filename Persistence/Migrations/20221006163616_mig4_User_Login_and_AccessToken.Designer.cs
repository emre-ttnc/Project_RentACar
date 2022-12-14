// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(RentACarDbContext))]
    [Migration("20221006163616_mig4_User_Login_and_AccessToken")]
    partial class mig4_User_Login_and_AccessToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CarEntities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("BrandName");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CarEntities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<int>("CarState")
                        .HasColumnType("integer")
                        .HasColumnName("CarState");

                    b.Property<float>("DailyPrice")
                        .HasColumnType("real")
                        .HasColumnName("DailyPrice");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ImageURL");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid");

                    b.Property<int>("ModelYear")
                        .HasColumnType("integer")
                        .HasColumnName("ModelYear");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CarEntities.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ModelName");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("integer")
                        .HasColumnName("AuthenticatorType");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Claim")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Claim");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CarEntities.Car", b =>
                {
                    b.HasOne("Domain.Entities.CarEntities.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Domain.Entities.CarEntities.Model", b =>
                {
                    b.HasOne("Domain.Entities.CarEntities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.UserClaim", b =>
                {
                    b.HasOne("Domain.Entities.UserEntities.User", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.CarEntities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.Entities.CarEntities.Model", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.User", b =>
                {
                    b.Navigation("UserClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
