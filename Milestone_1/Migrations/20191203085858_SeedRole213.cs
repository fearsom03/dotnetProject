using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class SeedRole213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "410e758d-0df2-4b25-916a-414526a57d04", "eda70264-cbc2-4fc0-92cc-de82215815b7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c680327-4cd7-4aed-bc26-60d3aeb16443", "dc919b03-18d2-46d3-a8a0-4758dc57b10a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "410e758d-0df2-4b25-916a-414526a57d04", "eda70264-cbc2-4fc0-92cc-de82215815b7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9c680327-4cd7-4aed-bc26-60d3aeb16443", "dc919b03-18d2-46d3-a8a0-4758dc57b10a" });
        }
    }
}
