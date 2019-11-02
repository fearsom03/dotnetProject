using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_UserData_userdataid",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_userdataid",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.RenameTable(
                name: "UserData",
                newName: "userDatas");

            migrationBuilder.RenameColumn(
                name: "userdataid",
                table: "users",
                newName: "userdataID");

            migrationBuilder.AlterColumn<int>(
                name: "userdataID",
                table: "users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userDatas",
                table: "userDatas",
                column: "id");

            migrationBuilder.CreateTable(
                name: "followers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userMeId = table.Column<int>(nullable: false),
                    UserToFollowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tweets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userId = table.Column<int>(nullable: false),
                    tweet = table.Column<string>(nullable: true),
                    post_date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tweets", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "followers");

            migrationBuilder.DropTable(
                name: "tweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userDatas",
                table: "userDatas");

            migrationBuilder.RenameTable(
                name: "userDatas",
                newName: "UserData");

            migrationBuilder.RenameColumn(
                name: "userdataID",
                table: "users",
                newName: "userdataid");

            migrationBuilder.AlterColumn<int>(
                name: "userdataid",
                table: "users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_users_userdataid",
                table: "users",
                column: "userdataid");

            migrationBuilder.AddForeignKey(
                name: "FK_users_UserData_userdataid",
                table: "users",
                column: "userdataid",
                principalTable: "UserData",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
