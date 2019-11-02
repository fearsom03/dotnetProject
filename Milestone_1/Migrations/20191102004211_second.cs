using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userDatas_users_userId",
                table: "userDatas");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "tweets");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "userDatas",
                newName: "UserForeignKey");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "userDatas",
                newName: "UserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_userDatas_userId",
                table: "userDatas",
                newName: "IX_userDatas_UserForeignKey");

            migrationBuilder.RenameColumn(
                name: "tweet",
                table: "tweets",
                newName: "tweetText");

            migrationBuilder.RenameColumn(
                name: "UserToFollowId",
                table: "followers",
                newName: "UserToFollowid");

            migrationBuilder.RenameColumn(
                name: "userMeId",
                table: "followers",
                newName: "UserToFollowForeignKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "post_date",
                table: "tweets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "tweets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDataId",
                table: "tweets",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserToFollowid",
                table: "followers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserDataId",
                table: "followers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tweetsid = table.Column<int>(nullable: true),
                    UserDataId = table.Column<int>(nullable: true),
                    commentText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_tweets_Tweetsid",
                        column: x => x.Tweetsid,
                        principalTable: "tweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_userDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "userDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "UserDataGroup",
                columns: table => new
                {
                    UserDataId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDataGroup", x => new { x.UserDataId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserDataGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDataGroup_userDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "userDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tweets_GroupId",
                table: "tweets",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tweets_UserDataId",
                table: "tweets",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_followers_UserDataId",
                table: "followers",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_followers_UserToFollowid",
                table: "followers",
                column: "UserToFollowid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Tweetsid",
                table: "Comment",
                column: "Tweetsid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserDataId",
                table: "Comment",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDataGroup_GroupId",
                table: "UserDataGroup",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_followers_userDatas_UserDataId",
                table: "followers",
                column: "UserDataId",
                principalTable: "userDatas",
                principalColumn: "UserDataId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_followers_users_UserToFollowid",
                table: "followers",
                column: "UserToFollowid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tweets_Group_GroupId",
                table: "tweets",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tweets_userDatas_UserDataId",
                table: "tweets",
                column: "UserDataId",
                principalTable: "userDatas",
                principalColumn: "UserDataId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userDatas_users_UserForeignKey",
                table: "userDatas",
                column: "UserForeignKey",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_followers_userDatas_UserDataId",
                table: "followers");

            migrationBuilder.DropForeignKey(
                name: "FK_followers_users_UserToFollowid",
                table: "followers");

            migrationBuilder.DropForeignKey(
                name: "FK_tweets_Group_GroupId",
                table: "tweets");

            migrationBuilder.DropForeignKey(
                name: "FK_tweets_userDatas_UserDataId",
                table: "tweets");

            migrationBuilder.DropForeignKey(
                name: "FK_userDatas_users_UserForeignKey",
                table: "userDatas");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "UserDataGroup");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_tweets_GroupId",
                table: "tweets");

            migrationBuilder.DropIndex(
                name: "IX_tweets_UserDataId",
                table: "tweets");

            migrationBuilder.DropIndex(
                name: "IX_followers_UserDataId",
                table: "followers");

            migrationBuilder.DropIndex(
                name: "IX_followers_UserToFollowid",
                table: "followers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "tweets");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "tweets");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "followers");

            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                table: "userDatas",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserDataId",
                table: "userDatas",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_userDatas_UserForeignKey",
                table: "userDatas",
                newName: "IX_userDatas_userId");

            migrationBuilder.RenameColumn(
                name: "tweetText",
                table: "tweets",
                newName: "tweet");

            migrationBuilder.RenameColumn(
                name: "UserToFollowid",
                table: "followers",
                newName: "UserToFollowId");

            migrationBuilder.RenameColumn(
                name: "UserToFollowForeignKey",
                table: "followers",
                newName: "userMeId");

            migrationBuilder.AlterColumn<string>(
                name: "post_date",
                table: "tweets",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "tweets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserToFollowId",
                table: "followers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
