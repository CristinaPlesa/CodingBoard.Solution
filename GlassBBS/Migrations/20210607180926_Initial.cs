using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassBBS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    BoardId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardId);
                });

            migrationBuilder.CreateTable(
                name: "BoardUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    UserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PostAuthorId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_BoardUser_PostAuthorId",
                        column: x => x.PostAuthorId,
                        principalTable: "BoardUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ReplyAuthorId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_BoardUser_ReplyAuthorId",
                        column: x => x.ReplyAuthorId,
                        principalTable: "BoardUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardPosts",
                columns: table => new
                {
                    BoardPostId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    PostId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    BoardId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    BoardUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardPosts", x => x.BoardPostId);
                    table.ForeignKey(
                        name: "FK_BoardPosts_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardPosts_BoardUser_BoardUserId",
                        column: x => x.BoardUserId,
                        principalTable: "BoardUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostReplies",
                columns: table => new
                {
                    PostReplyId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    PostId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    ReplyId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    BoardUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReplies", x => x.PostReplyId);
                    table.ForeignKey(
                        name: "FK_PostReplies_BoardUser_BoardUserId",
                        column: x => x.BoardUserId,
                        principalTable: "BoardUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostReplies_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostReplies_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "ReplyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { "57c50e58-bce0-45d2-829f-eda7570600d4", "Information regarding various residency opportunities.", "Residencies" },
                    { "7165b229-0547-4a40-8226-6583b26e23c9", "A selection of educational workshop offerings.", "Workshops" },
                    { "a63fee92-36f4-41b1-8547-a831aa9d4238", "A list of institutions offering higher-ed degrees in the field.", "Education" },
                    { "e4739247-49d6-4f7f-a569-cf78c4fedb4b", "Scholarship info for workshops and universities.", "Scholarships" },
                    { "03cf0496-60aa-407f-836f-31e4e2958102", "View selected works/exhibitions by various artists", "Exhibitions" },
                    { "b5d0ad93-b9ab-4e9e-9aa6-5334cef8af7b", "Find relevant job info within the field.", "Jobs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardPosts_BoardId",
                table: "BoardPosts",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardPosts_BoardUserId",
                table: "BoardPosts",
                column: "BoardUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardPosts_PostId",
                table: "BoardPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_BoardUserId",
                table: "PostReplies",
                column: "BoardUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_PostId",
                table: "PostReplies",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_ReplyId",
                table: "PostReplies",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostAuthorId",
                table: "Posts",
                column: "PostAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ReplyAuthorId",
                table: "Replies",
                column: "ReplyAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardPosts");

            migrationBuilder.DropTable(
                name: "PostReplies");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "BoardUser");
        }
    }
}
