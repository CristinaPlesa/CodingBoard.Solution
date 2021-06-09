using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingBoard.Migrations
{
    public partial class Voting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumn: "BoardUserId",
                keyValue: "0db6f085-8080-4d62-b2c9-b7e37b99ec1a");

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumn: "BoardUserId",
                keyValue: "d631bc96-b710-483f-aec3-e21ea39cc298");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "45ee40ba-6faf-4cdd-9380-2fe4901b8b51");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "5486c8c8-2a46-4f13-8fae-a8091a27c5de");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "bef4ef2d-c1ae-4a6b-a325-9e8c8e783fff");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "c50cbddc-122b-47db-8265-de0fbd46079c");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "d67a6f22-c7b7-4215-b2a1-c41584dc36f6");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "e4f3ca2d-bba4-4113-9885-9ac679c2b9ad");

            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "BoardUsers",
                columns: new[] { "BoardUserId", "Name" },
                values: new object[,]
                {
                    { "170eae01-745b-48bd-9aa8-83ec15248eed", "Cristina" },
                    { "9623f71e-964e-4054-b160-2e48062d0767", "Tom" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { "adf76307-4356-4ebc-ba4c-2b870b1222f2", "A selection of upcoming coding events.", "Events" },
                    { "bd30ea21-e107-4cb0-bd76-3d27c9a9672d", "A list of institutions offering higher-ed degrees in the field.", "Education" },
                    { "ae277ece-4998-4552-a0cb-d103e41c834e", "Memes", "Memes" },
                    { "62545e46-1907-4338-8ad6-9a21d4becc34", "Scholarship info for bootcamps and universities.", "Scholarships" },
                    { "b067301e-cdaa-4717-86dc-ea53c4ceae1e", "View selected works/projects by various coders", "Projects" },
                    { "7d9b8c30-38b7-4500-a797-83cea275bfb5", "Find relevant job info within the field.", "Jobs" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumn: "BoardUserId",
                keyValue: "170eae01-745b-48bd-9aa8-83ec15248eed");

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumn: "BoardUserId",
                keyValue: "9623f71e-964e-4054-b160-2e48062d0767");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "62545e46-1907-4338-8ad6-9a21d4becc34");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "7d9b8c30-38b7-4500-a797-83cea275bfb5");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "adf76307-4356-4ebc-ba4c-2b870b1222f2");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "ae277ece-4998-4552-a0cb-d103e41c834e");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "b067301e-cdaa-4717-86dc-ea53c4ceae1e");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "bd30ea21-e107-4cb0-bd76-3d27c9a9672d");

            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "Posts");

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
        }
    }
}
