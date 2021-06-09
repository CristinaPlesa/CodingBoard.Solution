using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingBoard.Migrations
{
    public partial class VoteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "BoardUsers",
                columns: new[] { "BoardUserId", "Name" },
                values: new object[,]
                {
                    { "acde35d6-c90b-44f6-ab53-bd7139a15c9a", "Cristina" },
                    { "2243f196-2d2f-4e43-a639-a53697b1be54", "Tom" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { "343acd9a-0e1e-4f4f-a0b4-a3ddf0cdc147", "A selection of upcoming coding events.", "Events" },
                    { "962d1b5b-31bc-4948-943e-bd9b9ca93c82", "A list of institutions offering higher-ed degrees in the field.", "Education" },
                    { "e838255f-ef9d-420f-ba9f-90c07fb34a4e", "Memes", "Memes" },
                    { "1d69a051-733d-4aa0-9bab-996aa2bb619a", "Scholarship info for bootcamps and universities.", "Scholarships" },
                    { "add4d144-73fb-4fca-867f-0fbea67860ad", "View selected works/projects by various coders", "Projects" },
                    { "dcceefd2-6ac3-4b04-b384-804d29c0b364", "Find relevant job info within the field.", "Jobs" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumn: "BoardUserId",
                keyValue: "2243f196-2d2f-4e43-a639-a53697b1be54");

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumn: "BoardUserId",
                keyValue: "acde35d6-c90b-44f6-ab53-bd7139a15c9a");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "1d69a051-733d-4aa0-9bab-996aa2bb619a");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "343acd9a-0e1e-4f4f-a0b4-a3ddf0cdc147");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "962d1b5b-31bc-4948-943e-bd9b9ca93c82");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "add4d144-73fb-4fca-867f-0fbea67860ad");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "dcceefd2-6ac3-4b04-b384-804d29c0b364");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "e838255f-ef9d-420f-ba9f-90c07fb34a4e");

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
    }
}
