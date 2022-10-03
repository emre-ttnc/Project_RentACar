using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig2_CarModelEntities_SeedDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2626699a-65e0-4178-8ef1-fa126d213009"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2e66232f-2e1d-44a4-8e9b-f7c29ff3e88f"));

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelYear = table.Column<int>(type: "integer", nullable: false),
                    DailyPrice = table.Column<float>(type: "real", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    CarState = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { new Guid("2b982286-7595-450a-a526-9fd57e1b787b"), "Mercedes-Benz" },
                    { new Guid("5901bbfb-8007-46c5-9fe7-8f7f5cabdd72"), "BMW" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "ModelName" },
                values: new object[,]
                {
                    { new Guid("1de0d0be-aabc-4dae-88fd-97c4ac876771"), new Guid("2b982286-7595-450a-a526-9fd57e1b787b"), "A 180" },
                    { new Guid("43c6c771-89e4-4ff1-a6bc-0cc715cebe47"), new Guid("5901bbfb-8007-46c5-9fe7-8f7f5cabdd72"), "Series 3" },
                    { new Guid("acdaf1bf-fcba-4167-af9c-d7c9cddce821"), new Guid("5901bbfb-8007-46c5-9fe7-8f7f5cabdd72"), "Series 4" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarState", "DailyPrice", "ImageURL", "ModelId", "ModelYear" },
                values: new object[,]
                {
                    { new Guid("2fd9af93-9787-4fe9-b2cc-1f439cfbf121"), 0, 800f, " ", new Guid("1de0d0be-aabc-4dae-88fd-97c4ac876771"), 2022 },
                    { new Guid("46017c0a-9f3d-429a-ab02-70b6ea686310"), 0, 800f, " ", new Guid("43c6c771-89e4-4ff1-a6bc-0cc715cebe47"), 2021 },
                    { new Guid("95b2cc23-4768-496a-ab37-be911b02d697"), 0, 1000f, " ", new Guid("acdaf1bf-fcba-4167-af9c-d7c9cddce821"), 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2b982286-7595-450a-a526-9fd57e1b787b"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("5901bbfb-8007-46c5-9fe7-8f7f5cabdd72"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { new Guid("2626699a-65e0-4178-8ef1-fa126d213009"), "BMW" },
                    { new Guid("2e66232f-2e1d-44a4-8e9b-f7c29ff3e88f"), "Mercedes-Benz" }
                });
        }
    }
}
