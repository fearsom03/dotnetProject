using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone_1.Migrations
{
    public partial class Bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "410e758d-0df2-4b25-916a-414526a57d04", "eda70264-cbc2-4fc0-92cc-de82215815b7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9c680327-4cd7-4aed-bc26-60d3aeb16443", "dc919b03-18d2-46d3-a8a0-4758dc57b10a" });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: false),
                    discription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(maxLength: 20, nullable: false),
                    password = table.Column<string>(nullable: false)
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
                    name = table.Column<string>(nullable: false),
                    surname = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    birthDate = table.Column<int>(nullable: false)
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
                    UserToFollowForeignKey = table.Column<int>(nullable: false)
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
                        name: "FK_followers_users_UserToFollowForeignKey",
                        column: x => x.UserToFollowForeignKey,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tweets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserDataForeignKey = table.Column<int>(nullable: false),
                    tweetText = table.Column<string>(nullable: true),
                    post_date = table.Column<DateTime>(nullable: false),
                    GroupForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tweets", x => x.id);
                    table.ForeignKey(
                        name: "FK_tweets_groups_GroupForeignKey",
                        column: x => x.GroupForeignKey,
                        principalTable: "groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tweets_userDatas_UserDataForeignKey",
                        column: x => x.UserDataForeignKey,
                        principalTable: "userDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userDataGroups",
                columns: table => new
                {
                    UserDataForeignKey = table.Column<int>(nullable: false),
                    GroupForeignKey = table.Column<int>(nullable: false),
                    UserForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDataGroups", x => new { x.UserDataForeignKey, x.GroupForeignKey });
                    table.ForeignKey(
                        name: "FK_userDataGroups_groups_GroupForeignKey",
                        column: x => x.GroupForeignKey,
                        principalTable: "groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userDataGroups_userDatas_UserDataForeignKey",
                        column: x => x.UserDataForeignKey,
                        principalTable: "userDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TweetForeignKey = table.Column<int>(nullable: false),
                    UserDataId = table.Column<int>(nullable: false),
                    commentText = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_tweets_TweetForeignKey",
                        column: x => x.TweetForeignKey,
                        principalTable: "tweets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_userDatas_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "userDatas",
                        principalColumn: "UserDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d58b97fd-63ee-4c23-b9ab-df98c67dea3b", "62ae54ac-a6bf-45e6-b2d9-0e2d04264175", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55e6d5e6-d473-4724-9e17-71c2f8aade9d", "67561daa-fe4e-4ffe-b6c0-cc4d1c0c1be7", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_comments_TweetForeignKey",
                table: "comments",
                column: "TweetForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserDataId",
                table: "comments",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_followers_UserDataId",
                table: "followers",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_followers_UserToFollowForeignKey",
                table: "followers",
                column: "UserToFollowForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_tweets_GroupForeignKey",
                table: "tweets",
                column: "GroupForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_tweets_UserDataForeignKey",
                table: "tweets",
                column: "UserDataForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_userDataGroups_GroupForeignKey",
                table: "userDataGroups",
                column: "GroupForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_userDatas_UserForeignKey",
                table: "userDatas",
                column: "UserForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "followers");

            migrationBuilder.DropTable(
                name: "userDataGroups");

            migrationBuilder.DropTable(
                name: "tweets");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "userDatas");

            migrationBuilder.DropTable(
                name: "users");

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
                values: new object[] { "410e758d-0df2-4b25-916a-414526a57d04", "eda70264-cbc2-4fc0-92cc-de82215815b7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c680327-4cd7-4aed-bc26-60d3aeb16443", "dc919b03-18d2-46d3-a8a0-4758dc57b10a", "Admin", "ADMIN" });
        }
    }
}
