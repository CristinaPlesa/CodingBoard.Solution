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
  public class RepliesController : ControllerBase
  {
    private readonly CodingBoardContext _db;

    public RepliesController(CodingBoardContext db)
    {
      _db = db;
    }

    [HttpGet("/api/board/{boardId}/posts/{postId}/replies")]
    public ActionResult<IEnumerable<Reply>> Replies(string boardId, string postId)
    {
      Console.WriteLine("HIT BOARD {0} / POST {1} / all replies", boardId, postId);
      Post post = _db.Posts.FirstOrDefault(p => p.PostId == postId);
      return post.Replies.ToList();
    }

    // [HttpPost("/api/board/{boardId}/posts/{postId}/replies/new")]
    // public async Task<ActionResult<Reply>> NewReply(string body, string replyAuthorId, string boardId, string postId)
    // {
    //   Reply newReply = new() { Body = body, ReplyAuthorId = replyAuthorId };
    //   _db.Replies.Add(newReply);
    //   await _db.SaveChangesAsync();
    //   return CreatedAtAction("NewReply", new { id = newReply.ReplyId }, newReply);
    // }

    // [HttpDelete("/api/board/{boardId}/posts/{postId}/delete")]
    // public async Task<IActionResult> DeletePost(string postId)
    // {
    //   Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == postId);
    //   _db.Posts.Remove(thisPost);
    //   await _db.SaveChangesAsync();
    //   return NoContent();
    // }

    // [HttpPut("/api/posts/edit/{postId}")]
    // public async Task<IActionResult> EditPost(string postId, Post thePost)
    // {
    //   Console.WriteLine("HIT PUT edit POSTS ROUTE {0} {1} ", postId, thePost);
    //   // Post thisPost = _db.Posts.FirstOrDefault(p => p.PostId == postId);
    //   _db.Entry(thePost).State = EntityState.Modified;
    //   try
    //   {
    //     await _db.SaveChangesAsync();
    //   }
    //   catch (DbUpdateConcurrencyException)
    //   {
    //     if (PostExists(postId))
    //     {
    //       return NotFound();
    //     }
    //     else
    //     {
    //       throw;
    //     }
    //   }
    //   return NoContent();
    // }

    // private bool PostExists(string postId)
    // {
    //   return _db.Posts.Any(p => p.PostId == postId);
    // }
  }
}
