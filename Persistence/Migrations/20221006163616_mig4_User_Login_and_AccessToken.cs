using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig4_User_Login_and_AccessToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Claims_ClaimId",
                table: "UserClaims");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_ClaimId",
                table: "UserClaims");

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

            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "UserClaims");

            migrationBuilder.AddColumn<string>(
                name: "Claim",
                table: "UserClaims",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Claim",
                table: "UserClaims");

            migrationBuilder.AddColumn<Guid>(
                name: "ClaimId",
                table: "UserClaims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Claims_ClaimId",
                table: "UserClaims",
                column: "ClaimId",
                principalTable: "Claims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
