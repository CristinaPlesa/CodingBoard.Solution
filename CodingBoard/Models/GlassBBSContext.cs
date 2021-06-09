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
      // builder.Entity<Post>()
      // .HasData(
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Residencies Test 1", BoardUserId = "2a1c7cf9-6d85-4354-b296-abb70d34df19", BoardId = "6e084970-2163-4947-a917-764c0da60585" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Workshops. Some super exciting info", BoardUserId = "3ef0b94c-4ab9-4e31-8dfe-d78fba164d96", BoardId = "a28e707b-88df-4bcf-ba43-79a18c5b3d26" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Education. Some super exciting info", BoardUserId = "3ef0b94c-4ab9-4e31-8dfe-d78fba164d96", BoardId = "aa23e6cf-e1b5-4d45-a725-400338d52d13" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Scholarships Test 1", BoardUserId = "2a1c7cf9-6d85-4354-b296-abb70d34df19", BoardId = "21cfd133-de11-4014-aea1-f4daabdb4c8d" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Exhibitions Test 1", BoardUserId = "2a1c7cf9-6d85-4354-b296-abb70d34df19", BoardId = "35f99108-4e05-4d82-aa67-775814c28b41" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Jobs Test 1", BoardUserId = "2a1c7cf9-6d85-4354-b296-abb70d34df19", BoardId = "7f19cf59-3557-4f78-b3ec-ca299baa01ea" }
      // );

      builder.Entity<Board>()
      .HasData(
        new Board { BoardId = Guid.NewGuid().ToString(), Name = "Residencies", Description = "Information regarding various residency opportunities." },
        new Board { BoardId = Guid.NewGuid().ToString(), Name = "Workshops", Description = "A selection of educational workshop offerings." },
        new Board { BoardId = Guid.NewGuid().ToString(), Name = "Education", Description = "A list of institutions offering higher-ed degrees in the field." },
        new Board { BoardId = Guid.NewGuid().ToString(), Name = "Scholarships", Description = "Scholarship info for workshops and universities." },
        new Board { BoardId = Guid.NewGuid().ToString(), Name = "Exhibitions", Description = "View selected works/exhibitions by various artists" },
        new Board { BoardId = Guid.NewGuid().ToString(), Name = "Jobs", Description = "Find relevant job info within the field." }
      );

      builder.Entity<BoardUser>()
        .HasData(
          new BoardUser { BoardUserId = Guid.NewGuid().ToString(), Name = "Max" },
          new BoardUser { BoardUserId = Guid.NewGuid().ToString(), Name = "Tom" }
        );
    }
  }
}


// BoardUsers
// '19854889-dc5b-4edc-8ee9-41144a724dff','Max'
// 'd3845ecc-261f-423b-a076-524adcd23482','Tom'

// Boards
// '00da967a-652d-4c9d-b9ef-f1bea2111d1d','Residencies','Information regarding various residency opportunities.'
// '227c89ae-57c0-4c71-ae95-8c8be11d511d','Workshops','A selection of educational workshop offerings.'
// '2d993c3d-72d7-491f-97dc-3c38cfbcbb8e','Education','A list of institutions offering higher-ed degrees in the field.'
// '68fb0ed7-d268-438c-859c-0f83cfe99dc4','Jobs','Find relevant job info within the field.'
// '9dd9f397-76d8-41d6-8232-9fe67a09add2','Scholarships','Scholarship info for workshops and universities.'
// 'e08c3b28-bcfa-4040-97fc-7acdf10328c7','Exhibitions','View selected works/exhibitions by various artists'

// Posts
