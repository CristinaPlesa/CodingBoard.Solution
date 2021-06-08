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
                    { "19854889-dc5b-4edc-8ee9-41144a724dff", "Max" },
                    { "d3845ecc-261f-423b-a076-524adcd23482", "Tom" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { "00da967a-652d-4c9d-b9ef-f1bea2111d1d", "Information regarding various residency opportunities.", "Residencies" },
                    { "227c89ae-57c0-4c71-ae95-8c8be11d511d", "A selection of educational workshop offerings.", "Workshops" },
                    { "2d993c3d-72d7-491f-97dc-3c38cfbcbb8e", "A list of institutions offering higher-ed degrees in the field.", "Education" },
                    { "9dd9f397-76d8-41d6-8232-9fe67a09add2", "Scholarship info for workshops and universities.", "Scholarships" },
                    { "e08c3b28-bcfa-4040-97fc-7acdf10328c7", "View selected works/exhibitions by various artists", "Exhibitions" },
                    { "68fb0ed7-d268-438c-859c-0f83cfe99dc4", "Find relevant job info within the field.", "Jobs" }
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
