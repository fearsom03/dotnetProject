using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations.Twitter
{
    public partial class SeedRole21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ac8164ac-c458-4b15-ba8d-57e03525d9c8", "ae1d2580-2261-461b-ac5b-3dcb2e6a6356" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "eaefb4b7-4360-401d-a122-8ddb6510ac64", "46d9f5e5-5806-431f-a5e8-1de717117050" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de5a40af-8e96-4b73-b7d4-a03aef1b6550", "520012e8-e437-412f-9fc5-b79112b3103f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bed1dec5-6345-4038-bbdc-f144007ab123", "295adf97-3586-4324-b41c-28ba50e947c5", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bed1dec5-6345-4038-bbdc-f144007ab123", "295adf97-3586-4324-b41c-28ba50e947c5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "de5a40af-8e96-4b73-b7d4-a03aef1b6550", "520012e8-e437-412f-9fc5-b79112b3103f" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac8164ac-c458-4b15-ba8d-57e03525d9c8", "ae1d2580-2261-461b-ac5b-3dcb2e6a6356", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eaefb4b7-4360-401d-a122-8ddb6510ac64", "46d9f5e5-5806-431f-a5e8-1de717117050", "Admin", "ADMIN" });
        }
    }
}
