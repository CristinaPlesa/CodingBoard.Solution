using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodingBoard.Models;

namespace CodingBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly CodingBoardContext _db;

    public PostsController(CodingBoardContext db)
    {
      _db = db;
    }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Animal>>> Get(string species, string gender, string name)
    // {
    //   var query = _db.Animals.AsQueryable();

    //   if (species != null)
    //   {
    //     query = query.Where(entry => entry.Species == species);
    //   }

    //   if (gender != null)
    //   {
    //     query = query.Where(entry => entry.Gender == gender);
    //   }    

    //   if (name != null)
    //   {
    //     query = query.Where(entry => entry.Name == name);
    //   }      

    //   return await query.ToListAsync();
    // }

    [HttpGet("/api/posts/{boardId}")]
    public async Task<ActionResult<IEnumerable<Post>>> Posts(string boardId)
    {
      Console.WriteLine("HIT BOARD {0} /POSTS", boardId);
      var query = _db.Posts.AsQueryable();
      query = query.Where(p => p.BoardId == boardId);
      return await query.ToListAsync();
    }


    [HttpPost("/api/posts/{newPost}")]
    public async Task<ActionResult<Post>> NewPost(Post newPost)
    {
      Console.WriteLine("\n\nAPI - creating new post {0} {1} {2}", newPost.Body, newPost.BoardUserId, newPost.BoardId);
      Post generatedPost = new() { Body = newPost.Body, BoardUserId = newPost.BoardUserId, BoardId = newPost.BoardId, VoteCount = 0 };
      Console.WriteLine("API before NEW POST CREATED {0} {1} {2}", generatedPost.Body, generatedPost.BoardId, generatedPost.BoardUserId);
      _db.Posts.Add(generatedPost);
      Console.WriteLine("\nAPI after add new post");
      await _db.SaveChangesAsync();
      Console.WriteLine("\nAPI AFTER SAVING TO DB, new post ID: {0}", generatedPost.PostId);
      return CreatedAtAction(nameof(NewPost), new { id = generatedPost.PostId }, generatedPost);
    }
    // [HttpPost]
    // public async Task<ActionResult<Post>> NewPost(Post post)
    // {
    //   Console.WriteLine("\n\n\t posts controller on the back end - new post route {0}", post);
    //   _db.Posts.Add(post);
    //   await _db.SaveChangesAsync();

    //   return CreatedAtAction(nameof(NewPost), new { id = post.PostId }, post);
    // }

    [HttpDelete("/api/posts/{postId}")]
    public async Task<IActionResult> DeletePost(string postId)
    {
      Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == postId);
      _db.Posts.Remove(thisPost);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("/api/posts/{postId}")]
    public async Task<IActionResult> EditPost(string postId, Post thePost)
    {
      Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == postId);
      if (thisPost == null)
      {
        return NotFound();
      }
      else
      {
        _db.Entry(thePost).State = EntityState.Modified;
        try
        {
          await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (PostExists(postId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return NoContent();
      }
    }

    [HttpPost("/api/vote/{postId}")]
    public async Task<IActionResult> Vote(string postId, string upOrDown)
    {
      Post thisPost = _db.Posts.FirstOrDefault(r => r.PostId == postId);
      if (upOrDown == "up")
      {
        thisPost.VoteCount++;
      }
      else
      {
        thisPost.VoteCount--;
      }
      await _db.SaveChangesAsync();
      return NoContent();
    }
    private bool PostExists(string postId)
    {
      return _db.Posts.Any(p => p.PostId == postId);
    }
  }
}