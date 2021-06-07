using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassBBS.Migrations
{
    public partial class AddsDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_BoardUser_PostAuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_BoardUser_ReplyAuthorId",
                table: "Replies");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "03cf0496-60aa-407f-836f-31e4e2958102");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "57c50e58-bce0-45d2-829f-eda7570600d4");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "7165b229-0547-4a40-8226-6583b26e23c9");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "a63fee92-36f4-41b1-8547-a831aa9d4238");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "b5d0ad93-b9ab-4e9e-9aa6-5334cef8af7b");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "e4739247-49d6-4f7f-a569-cf78c4fedb4b");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "BoardUser");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "BoardUser");

            migrationBuilder.RenameColumn(
                name: "ReplyAuthorId",
                table: "Replies",
                newName: "ReplyAuthorBoardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_ReplyAuthorId",
                table: "Replies",
                newName: "IX_Replies_ReplyAuthorBoardUserId");

            migrationBuilder.RenameColumn(
                name: "PostAuthorId",
                table: "Posts",
                newName: "PostAuthorBoardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostAuthorId",
                table: "Posts",
                newName: "IX_Posts_PostAuthorBoardUserId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "BoardUser",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BoardUser",
                newName: "BoardUserId");

            migrationBuilder.InsertData(
                table: "BoardUser",
                columns: new[] { "BoardUserId", "Name" },
                values: new object[,]
                {
                    { "f041cf14-4587-46af-b20c-c6514ed97185", "Max" },
                    { "7bb5cdb8-c18a-49cb-8dda-354ef8885a4b", "Tom" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { "0a825328-bfd4-421d-8d68-afe78178e388", "Information regarding various residency opportunities.", "Residencies" },
                    { "6c4428ba-9edb-4733-b982-b02420e53634", "A selection of educational workshop offerings.", "Workshops" },
                    { "a5c08454-6ac6-41c1-a754-21fa1cfd9486", "A list of institutions offering higher-ed degrees in the field.", "Education" },
                    { "bde4dbe9-9b24-44fd-bcff-c085a06bc69e", "Scholarship info for workshops and universities.", "Scholarships" },
                    { "4a6f4771-9bb0-471d-b335-17bdcfde6d9a", "View selected works/exhibitions by various artists", "Exhibitions" },
                    { "ab498cf9-cc76-4075-aae5-a6ae90f70b58", "Find relevant job info within the field.", "Jobs" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_BoardUser_PostAuthorBoardUserId",
                table: "Posts",
                column: "PostAuthorBoardUserId",
                principalTable: "BoardUser",
                principalColumn: "BoardUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_BoardUser_ReplyAuthorBoardUserId",
                table: "Replies",
                column: "ReplyAuthorBoardUserId",
                principalTable: "BoardUser",
                principalColumn: "BoardUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_BoardUser_PostAuthorBoardUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_BoardUser_ReplyAuthorBoardUserId",
                table: "Replies");

            migrationBuilder.DeleteData(
                table: "BoardUser",
                keyColumn: "BoardUserId",
                keyValue: "7bb5cdb8-c18a-49cb-8dda-354ef8885a4b");

            migrationBuilder.DeleteData(
                table: "BoardUser",
                keyColumn: "BoardUserId",
                keyValue: "f041cf14-4587-46af-b20c-c6514ed97185");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "0a825328-bfd4-421d-8d68-afe78178e388");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "4a6f4771-9bb0-471d-b335-17bdcfde6d9a");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "6c4428ba-9edb-4733-b982-b02420e53634");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "a5c08454-6ac6-41c1-a754-21fa1cfd9486");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "ab498cf9-cc76-4075-aae5-a6ae90f70b58");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: "bde4dbe9-9b24-44fd-bcff-c085a06bc69e");

            migrationBuilder.RenameColumn(
                name: "ReplyAuthorBoardUserId",
                table: "Replies",
                newName: "ReplyAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_ReplyAuthorBoardUserId",
                table: "Replies",
                newName: "IX_Replies_ReplyAuthorId");

            migrationBuilder.RenameColumn(
                name: "PostAuthorBoardUserId",
                table: "Posts",
                newName: "PostAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostAuthorBoardUserId",
                table: "Posts",
                newName: "IX_Posts_PostAuthorId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BoardUser",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "BoardUserId",
                table: "BoardUser",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "BoardUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "BoardUser",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BoardUser",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "BoardUser",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "BoardUser",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "BoardUser",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "BoardUser",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "BoardUser",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "BoardUser",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "BoardUser",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "BoardUser",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "BoardUser",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "BoardUser",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_BoardUser_PostAuthorId",
                table: "Posts",
                column: "PostAuthorId",
                principalTable: "BoardUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_BoardUser_ReplyAuthorId",
                table: "Replies",
                column: "ReplyAuthorId",
                principalTable: "BoardUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
