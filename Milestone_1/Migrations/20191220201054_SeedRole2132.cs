using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class SeedRole2132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "55e6d5e6-d473-4724-9e17-71c2f8aade9d", "67561daa-fe4e-4ffe-b6c0-cc4d1c0c1be7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d58b97fd-63ee-4c23-b9ab-df98c67dea3b", "62ae54ac-a6bf-45e6-b2d9-0e2d04264175" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b80470eb-c66d-4e6e-8e76-942c50d44130", "cad1e840-7b86-4ac9-bd30-ef517dd3cbfc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e432832-c9f3-418f-a0ac-2b8248a2a7aa", "053c4d26-a94e-4440-be11-b87d6438c4f2", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4e432832-c9f3-418f-a0ac-2b8248a2a7aa", "053c4d26-a94e-4440-be11-b87d6438c4f2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b80470eb-c66d-4e6e-8e76-942c50d44130", "cad1e840-7b86-4ac9-bd30-ef517dd3cbfc" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d58b97fd-63ee-4c23-b9ab-df98c67dea3b", "62ae54ac-a6bf-45e6-b2d9-0e2d04264175", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55e6d5e6-d473-4724-9e17-71c2f8aade9d", "67561daa-fe4e-4ffe-b6c0-cc4d1c0c1be7", "Admin", "ADMIN" });
        }
    }
}
