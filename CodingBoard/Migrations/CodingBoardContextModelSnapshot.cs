﻿// <auto-generated />
using CodingBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodingBoard.Migrations
{
    [DbContext(typeof(CodingBoardContext))]
    partial class CodingBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CodingBoard.Models.Board", b =>
                {
                    b.Property<string>("BoardId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("BoardId");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            BoardId = "343acd9a-0e1e-4f4f-a0b4-a3ddf0cdc147",
                            Description = "A selection of upcoming coding events.",
                            Name = "Events"
                        },
                        new
                        {
                            BoardId = "962d1b5b-31bc-4948-943e-bd9b9ca93c82",
                            Description = "A list of institutions offering higher-ed degrees in the field.",
                            Name = "Education"
                        },
                        new
                        {
                            BoardId = "e838255f-ef9d-420f-ba9f-90c07fb34a4e",
                            Description = "Memes",
                            Name = "Memes"
                        },
                        new
                        {
                            BoardId = "1d69a051-733d-4aa0-9bab-996aa2bb619a",
                            Description = "Scholarship info for bootcamps and universities.",
                            Name = "Scholarships"
                        },
                        new
                        {
                            BoardId = "add4d144-73fb-4fca-867f-0fbea67860ad",
                            Description = "View selected works/projects by various coders",
                            Name = "Projects"
                        },
                        new
                        {
                            BoardId = "dcceefd2-6ac3-4b04-b384-804d29c0b364",
                            Description = "Find relevant job info within the field.",
                            Name = "Jobs"
                        });
                });

            modelBuilder.Entity("CodingBoard.Models.BoardUser", b =>
                {
                    b.Property<string>("BoardUserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("BoardUserId");

                    b.ToTable("BoardUsers");

                    b.HasData(
                        new
                        {
                            BoardUserId = "acde35d6-c90b-44f6-ab53-bd7139a15c9a",
                            Name = "Cristina"
                        },
                        new
                        {
                            BoardUserId = "2243f196-2d2f-4e43-a639-a53697b1be54",
                            Name = "Tom"
                        });
                });

            modelBuilder.Entity("CodingBoard.Models.Post", b =>
                {
                    b.Property<string>("PostId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("BoardId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("BoardUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("VoteCount")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("BoardId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CodingBoard.Models.Reply", b =>
                {
                    b.Property<string>("ReplyId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("BoardUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PostId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("VoteCount")
                        .HasColumnType("int");

                    b.HasKey("ReplyId");

                    b.HasIndex("PostId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("CodingBoard.Models.Post", b =>
                {
                    b.HasOne("CodingBoard.Models.Board", null)
                        .WithMany("Posts")
                        .HasForeignKey("BoardId");
                });

            modelBuilder.Entity("CodingBoard.Models.Reply", b =>
                {
                    b.HasOne("CodingBoard.Models.Post", null)
                        .WithMany("Replies")
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("CodingBoard.Models.Board", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("CodingBoard.Models.Post", b =>
                {
                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
