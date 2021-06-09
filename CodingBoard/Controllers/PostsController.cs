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

    [HttpGet("/api/board/{BoardId}/posts")]
    public ActionResult<IEnumerable<Post>> Posts(string BoardId)
    {
      Console.WriteLine("HIT BOARD {0} /POSTS", BoardId);
      Board b = _db.Boards.FirstOrDefault(b => b.BoardId == BoardId);
      return b.Posts.ToList();

    }

    [HttpPost("/api/board/{boardId}/posts/new")]
    public async Task<ActionResult<Post>> NewPost(string body, string postAuthorId, string boardId)
    {
      Post newPost = new() { Body = body, PostAuthorId = postAuthorId, BoardId = boardId };
      _db.Posts.Add(newPost);
      await _db.SaveChangesAsync();
      return CreatedAtAction("NewPost", new { id = newPost.PostId }, newPost);
    }

    [HttpDelete("/api/board/{boardId}/posts/{postId}/delete")]
    public async Task<IActionResult> DeletePost(string postId)
    {
      Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == postId);
      _db.Posts.Remove(thisPost);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("/api/posts/edit/{postId}")]
    public async Task<IActionResult> EditPost(string postId, Post thePost)
    {
      Console.WriteLine("HIT PUT edit POSTS ROUTE {0} {1} ", postId, thePost);
      // Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == postId);
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

    private bool PostExists(string postId)
    {
      return _db.Posts.Any(p => p.PostId == postId);
    }
  }
}
