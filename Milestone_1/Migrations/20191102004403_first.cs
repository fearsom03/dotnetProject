using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userDatas",
                columns: table => new
                {
                    UserDataId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserForeignKey = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDatas", x => x.UserDataId);
                    table.ForeignKey(
                        name: "FK_userDatas_users_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "followers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserDataId = table.Column<int>(nullable: true),
                    UserToFollowForeignKey = table.Column<int>(nullable: false),
                    UserToFollowid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followers", x => x.id);
                    table.ForeignKey(
                        name: "FK_followers_userDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "userDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_followers_users_UserToFollowid",
                        column: x => x.UserToFollowid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tweets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserDataId = table.Column<int>(nullable: true),
                    tweetText = table.Column<string>(nullable: true),
                    post_date = table.Column<DateTime>(nullable: false),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tweets", x => x.id);
                    table.ForeignKey(
                        name: "FK_tweets_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tweets_userDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "userDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Tweetsid",
                table: "Comment",
                column: "Tweetsid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserDataId",
                table: "Comment",
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
                name: "IX_tweets_GroupId",
                table: "tweets",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tweets_UserDataId",
                table: "tweets",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDataGroup_GroupId",
                table: "UserDataGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_userDatas_UserForeignKey",
                table: "userDatas",
                column: "UserForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "followers");

            migrationBuilder.DropTable(
                name: "UserDataGroup");

            migrationBuilder.DropTable(
                name: "tweets");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "userDatas");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
