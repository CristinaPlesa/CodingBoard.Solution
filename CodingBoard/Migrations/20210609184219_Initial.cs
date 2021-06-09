using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingBoard.Migrations
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
                name: "BoardUsers",
                columns: table => new
                {
                    BoardUserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardUsers", x => x.BoardUserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PostAuthorId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BoardId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ReplyAuthorId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PostId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BoardUsers",
                columns: new[] { "BoardUserId", "Name" },
                values: new object[,]
                {
                    { "76022aa4-9a8c-4efc-ba7c-83b45946540e", "Cristina" },
                    { "c1cd5759-4195-4341-83cf-7ea8ba273d99", "Tom" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { "54b81afa-0458-485c-922a-e1703c30022f", "A selection of upcoming coding events.", "Events" },
                    { "c3febe61-d0bf-45eb-8126-7e060ba5f1a0", "A list of institutions offering higher-ed degrees in the field.", "Education" },
                    { "6497ef56-9b02-4913-8260-304c9090b07a", "Memes", "Memes" },
                    { "20303354-6327-49be-9da2-ed2b5d81d41c", "Scholarship info for bootcamps and universities.", "Scholarships" },
                    { "87ba011b-0221-4a3e-9f6f-14ff836cd0ea", "View selected works/projects by various coders", "Projects" },
                    { "855fb0cf-5cde-4b30-9a2a-14fb76615341", "Find relevant job info within the field.", "Jobs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BoardId",
                table: "Posts",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PostId",
                table: "Replies",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardUsers");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
