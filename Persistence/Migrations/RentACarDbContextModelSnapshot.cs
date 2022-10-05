﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(RentACarDbContext))]
    partial class RentACarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Brand", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("22065d60-d98f-47aa-887f-2e12dc9fb111"),
                            BrandName = "BMW"
                        },
                        new
                        {
                            Id = new Guid("25f94134-4fa3-4e70-84ec-ece4b0e030af"),
                            BrandName = "Mercedes-Benz"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f223b8c-5d54-4376-ab6e-2c126bfe20c1"),
                            CarState = 0,
                            DailyPrice = 1000f,
                            ImageURL = " ",
                            ModelId = new Guid("d1a5a743-c1d7-4674-b290-8dd340ea74d2"),
                            ModelYear = 2020
                        },
                        new
                        {
                            Id = new Guid("8ed8b418-e4ca-418a-9a9f-1c4cebb9696c"),
                            CarState = 0,
                            DailyPrice = 800f,
                            ImageURL = " ",
                            ModelId = new Guid("3d69542d-5d28-4db2-bb4b-e078b3a67deb"),
                            ModelYear = 2021
                        },
                        new
                        {
                            Id = new Guid("61bc2fd8-97ad-4e83-ac7a-477e07068fb4"),
                            CarState = 0,
                            DailyPrice = 800f,
                            ImageURL = " ",
                            ModelId = new Guid("465b80ba-b5b2-403a-b409-0fcd2187485d"),
                            ModelYear = 2022
                        });
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1a5a743-c1d7-4674-b290-8dd340ea74d2"),
                            BrandId = new Guid("22065d60-d98f-47aa-887f-2e12dc9fb111"),
                            ModelName = "Series 4"
                        },
                        new
                        {
                            Id = new Guid("3d69542d-5d28-4db2-bb4b-e078b3a67deb"),
                            BrandId = new Guid("22065d60-d98f-47aa-887f-2e12dc9fb111"),
                            ModelName = "Series 3"
                        },
                        new
                        {
                            Id = new Guid("465b80ba-b5b2-403a-b409-0fcd2187485d"),
                            BrandId = new Guid("25f94134-4fa3-4e70-84ec-ece4b0e030af"),
                            ModelName = "A 180"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.Claim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("ClaimName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ClaimName");

                    b.HasKey("Id");

                    b.ToTable("Claims", (string)null);
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

                    b.Property<Guid>("ClaimId")
                        .HasColumnType("uuid")
                        .HasColumnName("ClaimId");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.Entities.UserEntities.UserClaim", b =>
                {
                    b.HasOne("Domain.Entities.UserEntities.Claim", "Claim")
                        .WithMany()
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntities.User", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Claim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
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
