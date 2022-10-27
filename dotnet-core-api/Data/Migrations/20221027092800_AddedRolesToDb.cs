using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_core_api.Data.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aa193f7-b49d-41e0-a367-f30d3b24688e", "162cdbde-6891-4f08-ac5c-db26daea54ff", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5b6d863-62a0-4a02-83bb-0ff93abaf9ae", "9af12690-f5ed-4a29-b140-74b6aa9634e2", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa193f7-b49d-41e0-a367-f30d3b24688e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5b6d863-62a0-4a02-83bb-0ff93abaf9ae");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
