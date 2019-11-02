using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userDatas_users_userId",
                table: "userDatas");

            migrationBuilder.DropIndex(
                name: "IX_userDatas_userId",
                table: "userDatas");

            migrationBuilder.AddColumn<int>(
                name: "userdata",
                table: "users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userdata",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_userDatas_userId",
                table: "userDatas",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userDatas_users_userId",
                table: "userDatas",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
