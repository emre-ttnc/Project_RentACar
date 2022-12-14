using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig3_User_and_Security : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2fd9af93-9787-4fe9-b2cc-1f439cfbf121"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("46017c0a-9f3d-429a-ab02-70b6ea686310"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("95b2cc23-4768-496a-ab37-be911b02d697"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("1de0d0be-aabc-4dae-88fd-97c4ac876771"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("43c6c771-89e4-4ff1-a6bc-0cc715cebe47"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("acdaf1bf-fcba-4167-af9c-d7c9cddce821"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2b982286-7595-450a-a526-9fd57e1b787b"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("5901bbfb-8007-46c5-9fe7-8f7f5cabdd72"));

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { new Guid("22065d60-d98f-47aa-887f-2e12dc9fb111"), "BMW" },
                    { new Guid("25f94134-4fa3-4e70-84ec-ece4b0e030af"), "Mercedes-Benz" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "ModelName" },
                values: new object[,]
                {
                    { new Guid("3d69542d-5d28-4db2-bb4b-e078b3a67deb"), new Guid("22065d60-d98f-47aa-887f-2e12dc9fb111"), "Series 3" },
                    { new Guid("465b80ba-b5b2-403a-b409-0fcd2187485d"), new Guid("25f94134-4fa3-4e70-84ec-ece4b0e030af"), "A 180" },
                    { new Guid("d1a5a743-c1d7-4674-b290-8dd340ea74d2"), new Guid("22065d60-d98f-47aa-887f-2e12dc9fb111"), "Series 4" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarState", "DailyPrice", "ImageURL", "ModelId", "ModelYear" },
                values: new object[,]
                {
                    { new Guid("61bc2fd8-97ad-4e83-ac7a-477e07068fb4"), 0, 800f, " ", new Guid("465b80ba-b5b2-403a-b409-0fcd2187485d"), 2022 },
                    { new Guid("8ed8b418-e4ca-418a-9a9f-1c4cebb9696c"), 0, 800f, " ", new Guid("3d69542d-5d28-4db2-bb4b-e078b3a67deb"), 2021 },
                    { new Guid("9f223b8c-5d54-4376-ab6e-2c126bfe20c1"), 0, 1000f, " ", new Guid("d1a5a743-c1d7-4674-b290-8dd340ea74d2"), 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_ClaimId",
                table: "UserClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("61bc2fd8-97ad-4e83-ac7a-477e07068fb4"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8ed8b418-e4ca-418a-9a9f-1c4cebb9696c"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9f223b8c-5d54-4376-ab6e-2c126bfe20c1"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("3d69542d-5d28-4db2-bb4b-e078b3a67deb"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("465b80ba-b5b2-403a-b409-0fcd2187485d"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("d1a5a743-c1d7-4674-b290-8dd340ea74d2"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("22065d60-d98f-47aa-887f-2e12dc9fb111"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("25f94134-4fa3-4e70-84ec-ece4b0e030af"));

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
        }
    }
}
