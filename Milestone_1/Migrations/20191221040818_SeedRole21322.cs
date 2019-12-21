using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class SeedRole21322 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "981b162e-1237-4631-804a-61fc1532f866", "0f30bf70-8754-4c51-b919-a689813c28bf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54af6e41-742b-4d7a-b6ef-5c2933d717ba", "72e2640d-57d5-4202-8ce6-f140794e1ce8", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "54af6e41-742b-4d7a-b6ef-5c2933d717ba", "72e2640d-57d5-4202-8ce6-f140794e1ce8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "981b162e-1237-4631-804a-61fc1532f866", "0f30bf70-8754-4c51-b919-a689813c28bf" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b80470eb-c66d-4e6e-8e76-942c50d44130", "cad1e840-7b86-4ac9-bd30-ef517dd3cbfc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e432832-c9f3-418f-a0ac-2b8248a2a7aa", "053c4d26-a94e-4440-be11-b87d6438c4f2", "Admin", "ADMIN" });
        }
    }
}
