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
// ''76022aa4-9a8c-4efc-ba7c-83b45946540e', 'Cristina'
// 'c1cd5759-4195-4341-83cf-7ea8ba273d99', 'Tom'

// Boards
// '00da967a-652d-4c9d-b9ef-f1bea2111d1d','Residencies','Information regarding various residency opportunities.'
// '227c89ae-57c0-4c71-ae95-8c8be11d511d','Workshops','A selection of educational workshop offerings.'
// '2d993c3d-72d7-491f-97dc-3c38cfbcbb8e','Education','A list of institutions offering higher-ed degrees in the field.'
// '68fb0ed7-d268-438c-859c-0f83cfe99dc4','Jobs','Find relevant job info within the field.'
// '9dd9f397-76d8-41d6-8232-9fe67a09add2','Scholarships','Scholarship info for workshops and universities.'
// 'e08c3b28-bcfa-4040-97fc-7acdf10328c7','Exhibitions','View selected works/exhibitions by various artists'

// Posts
