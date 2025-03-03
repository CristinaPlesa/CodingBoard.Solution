﻿// <auto-generated />
using CodingBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodingBoard.Migrations
{
    [DbContext(typeof(CodingBoardContext))]
    [Migration("20210609224041_Voting")]
    partial class Voting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            BoardId = "adf76307-4356-4ebc-ba4c-2b870b1222f2",
                            Description = "A selection of upcoming coding events.",
                            Name = "Events"
                        },
                        new
                        {
                            BoardId = "bd30ea21-e107-4cb0-bd76-3d27c9a9672d",
                            Description = "A list of institutions offering higher-ed degrees in the field.",
                            Name = "Education"
                        },
                        new
                        {
                            BoardId = "ae277ece-4998-4552-a0cb-d103e41c834e",
                            Description = "Memes",
                            Name = "Memes"
                        },
                        new
                        {
                            BoardId = "62545e46-1907-4338-8ad6-9a21d4becc34",
                            Description = "Scholarship info for bootcamps and universities.",
                            Name = "Scholarships"
                        },
                        new
                        {
                            BoardId = "b067301e-cdaa-4717-86dc-ea53c4ceae1e",
                            Description = "View selected works/projects by various coders",
                            Name = "Projects"
                        },
                        new
                        {
                            BoardId = "7d9b8c30-38b7-4500-a797-83cea275bfb5",
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
                            BoardUserId = "170eae01-745b-48bd-9aa8-83ec15248eed",
                            Name = "Cristina"
                        },
                        new
                        {
                            BoardUserId = "9623f71e-964e-4054-b160-2e48062d0767",
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
