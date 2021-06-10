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

    [HttpGet("/api/boards/{boardId}/posts")]
    public ActionResult<IEnumerable<Post>> Posts(string boardId)
    {
      Console.WriteLine("HIT BOARD {0} /POSTS", boardId);
      Board b = _db.Boards.FirstOrDefault(b => b.BoardId == boardId);
      return b.Posts.ToList();

    }

    [HttpPost("/api/boards/{boardId}/posts/new")]
    public async Task<ActionResult<Post>> NewPost(string body, string boardUserId, string boardId)
    {
      Post newPost = new() { Body = body, BoardUserId = boardUserId, BoardId = boardId, VoteCount = 0 };
      _db.Posts.Add(newPost);
      await _db.SaveChangesAsync();
      return CreatedAtAction("NewPost", new { id = newPost.PostId }, newPost);
    }

    [HttpDelete("/api/posts/{postId}/delete")]
    public async Task<IActionResult> DeletePost(string postId)
    {
      Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == postId);
      _db.Posts.Remove(thisPost);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("/api/posts/{postId}/edit")]
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

    [HttpPost("/api/posts/{postId}/upvote")]
    public async Task<IActionResult> Upvote(string postId)
    {
      Post thisPost = _db.Posts.FirstOrDefault(r => r.PostId == postId);
      thisPost.VoteCount++;
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPost("/api/posts/{postId}/downvote")]
    public async Task<IActionResult> Downvote(string postId)
    {
      Post thisPost = _db.Posts.FirstOrDefault(r => r.PostId == postId);
      thisPost.VoteCount--;
      await _db.SaveChangesAsync();
      return NoContent();
    }
    private bool PostExists(string postId)
    {
      return _db.Posts.Any(p => p.PostId == postId);
    }
  }
}
