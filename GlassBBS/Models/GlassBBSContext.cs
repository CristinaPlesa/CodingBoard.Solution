using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GlassBBS.Models
{
  public class GlassBBSContext : DbContext
  {
    public GlassBBSContext(DbContextOptions<GlassBBSContext> options) : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<Board> Boards { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Reply> Replies { get; set; }
    public DbSet<BoardPost> BoardPosts { get; set; }
    public DbSet<PostReply> PostReplies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Board>()
        .HasData(
          new Board { BoardId = Guid.NewGuid().ToString(), Name = "Residencies", Description = "Information regarding various residency opportunities." },
          new Board { BoardId = Guid.NewGuid().ToString(), Name = "Workshops", Description = "A selection of educational workshop offerings." },
          new Board { BoardId = Guid.NewGuid().ToString(), Name = "Education", Description = "A list of institutions offering higher-ed degrees in the field." },
          new Board { BoardId = Guid.NewGuid().ToString(), Name = "Scholarships", Description = "Scholarship info for workshops and universities." },
          new Board { BoardId = Guid.NewGuid().ToString(), Name = "Exhibitions", Description = "View selected works/exhibitions by various artists" },
          new Board { BoardId = Guid.NewGuid().ToString(), Name = "Jobs", Description = "Find relevant job info within the field." }
        );
    }
  }
}
