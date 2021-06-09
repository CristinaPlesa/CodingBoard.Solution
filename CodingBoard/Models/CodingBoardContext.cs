using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodingBoard.Models
{
  public class CodingBoardContext : DbContext
  {
    public CodingBoardContext(DbContextOptions<CodingBoardContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<Board> Boards { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Reply> Replies { get; set; }
    public DbSet<BoardUser> BoardUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Board>()
      .HasData(
        new Board { Name = "Events", Description = "A selection of upcoming coding events." },
        new Board { Name = "Education", Description = "A list of institutions offering higher-ed degrees in the field." },
        new Board { Name = "Memes", Description = "Memes" },
        new Board { Name = "Scholarships", Description = "Scholarship info for bootcamps and universities." },
        new Board { Name = "Projects", Description = "View selected works/projects by various coders" },
        new Board { Name = "Jobs", Description = "Find relevant job info within the field." }
      );

      builder.Entity<BoardUser>()
        .HasData(
          new BoardUser { Name = "Cristina" },
          new BoardUser { Name = "Tom" }
        );
    }
  }
}

// BoardUsers
// '0db6f085-8080-4d62-b2c9-b7e37b99ec1a', 'Tom'
// 'd631bc96-b710-483f-aec3-e21ea39cc298', 'Cristina'

//     "boardId": "45ee40ba-6faf-4cdd-9380-2fe4901b8b51",
//     "name": "Jobs",
//     "boardId": "5486c8c8-2a46-4f13-8fae-a8091a27c5de",
//     "name": "Projects",
//     "boardId": "bef4ef2d-c1ae-4a6b-a325-9e8c8e783fff",
//     "name": "Education",
//     "boardId": "c50cbddc-122b-47db-8265-de0fbd46079c",
//     "name": "Scholarships",
//     "boardId": "d67a6f22-c7b7-4215-b2a1-c41584dc36f6",
//     "name": "Memes",
//     "boardId": "e4f3ca2d-bba4-4113-9885-9ac679c2b9ad",
//     "name": "Events",//     "description": "A selection of upcoming coding events.",

// Posts