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
                    BoardUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
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
                    BoardUserId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
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
                    { "d631bc96-b710-483f-aec3-e21ea39cc298", "Cristina" },
                    { "0db6f085-8080-4d62-b2c9-b7e37b99ec1a", "Tom" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { "e4f3ca2d-bba4-4113-9885-9ac679c2b9ad", "A selection of upcoming coding events.", "Events" },
                    { "bef4ef2d-c1ae-4a6b-a325-9e8c8e783fff", "A list of institutions offering higher-ed degrees in the field.", "Education" },
                    { "d67a6f22-c7b7-4215-b2a1-c41584dc36f6", "Memes", "Memes" },
                    { "c50cbddc-122b-47db-8265-de0fbd46079c", "Scholarship info for bootcamps and universities.", "Scholarships" },
                    { "5486c8c8-2a46-4f13-8fae-a8091a27c5de", "View selected works/projects by various coders", "Projects" },
                    { "45ee40ba-6faf-4cdd-9380-2fe4901b8b51", "Find relevant job info within the field.", "Jobs" }
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
