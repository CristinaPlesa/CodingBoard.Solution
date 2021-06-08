using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GlassBBS.Models
{
  public class GlassBBSContext : DbContext
  {
    public GlassBBSContext(DbContextOptions<GlassBBSContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<Board> Boards { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Reply> Replies { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Post>()
      // .HasData(
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Residencies Test 1", BoardUserId = "b5a92fe5-51c9-4ceb-a010-eb3044e94fa1", BoardId = "ea54f14a-da9c-446d-8fff-a1cd9b7d5574" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Workshops. Some super exciting info", BoardUserId = "b372f755-0829-40fa-9122-67dbd698a786", BoardId = "80e3e31b-1bfb-4637-be05-aa12f58a8c30" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Education. Some super exciting info", BoardUserId = "b372f755-0829-40fa-9122-67dbd698a786", BoardId = "f4583af1-26d8-48c3-b927-d8f456bd24cc" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Scholarships Test 1", BoardUserId = "b5a92fe5-51c9-4ceb-a010-eb3044e94fa1", BoardId = "d2821f17-2fd6-4852-8825-cf841af3c2fa" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Exhibitions Test 1", BoardUserId = "b5a92fe5-51c9-4ceb-a010-eb3044e94fa1", BoardId = "92a60c91-ae25-460f-9dd9-40b15b3179e0" },
      //   new Post { PostId = Guid.NewGuid().ToString(), Body = "Jobs Test 1", BoardUserId = "b5a92fe5-51c9-4ceb-a010-eb3044e94fa1", BoardId = "3cd2e069-5d26-4d43-903f-6f5de212ee10" }
      // );
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
// 'b372f755-0829-40fa-9122-67dbd698a786','Max'
// 'b5a92fe5-51c9-4ceb-a010-eb3044e94fa1','Tom'

// Boards
// '3cd2e069-5d26-4d43-903f-6f5de212ee10','Jobs','Find relevant job info within the field.'
// '80e3e31b-1bfb-4637-be05-aa12f58a8c30','Workshops','A selection of educational workshop offerings.'
// '92a60c91-ae25-460f-9dd9-40b15b3179e0','Exhibitions','View selected works/exhibitions by various artists'
// 'd2821f17-2fd6-4852-8825-cf841af3c2fa','Scholarships','Scholarship info for workshops and universities.'
// 'ea54f14a-da9c-446d-8fff-a1cd9b7d5574','Residencies','Information regarding various residency opportunities.'
// 'f4583af1-26d8-48c3-b927-d8f456bd24cc','Education','A list of institutions offering higher-ed degrees in the field.'

// Posts
