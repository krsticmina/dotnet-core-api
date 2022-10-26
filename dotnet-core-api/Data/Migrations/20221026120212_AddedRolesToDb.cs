using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_core_api.Data.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "003bca04-3755-4acf-aa20-b8347b0229b7", "b536a339-a72a-4dd3-bb9a-c46b9e7080ae", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be712f64-a91b-4207-93ea-713fa7a462af", "37ab59e7-8fea-4f18-ba0d-1980c51165ac", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "003bca04-3755-4acf-aa20-b8347b0229b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be712f64-a91b-4207-93ea-713fa7a462af");
        }
    }
}
