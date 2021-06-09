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

    [HttpPost("/api/board/{boardId}/posts/{postId}/replies/new")]
    public async Task<ActionResult<Reply>> NewReply(string body, string boardUserId, string boardId, string postId)
    {
      Console.WriteLine("HIT POST NEW REPLY");
      Reply newReply = new() { Body = body, BoardUserId = boardUserId, PostId = postId };
      _db.Replies.Add(newReply);
      await _db.SaveChangesAsync();
      return CreatedAtAction("NewReply", new { id = newReply.ReplyId }, newReply);
    }

    [HttpDelete("/api/board/{boardId}/posts/{postId}/replies/{replyId}/delete")]
    public async Task<IActionResult> DeleteReply(string replyId)
    {
      Reply thisReply = _db.Replies.FirstOrDefault(r => r.ReplyId == replyId);
      _db.Replies.Remove(thisReply);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("/api/board/{boardId}/posts/{postId}/replies/{replyId}/edit")]
    public async Task<IActionResult> EditReply(Reply theReply)
    {
      Console.WriteLine("HIT PUT edit REPLIES ROUTE. replyId: {0} \t body {1} \t board user id {2}", theReply.ReplyId, theReply.Body, theReply.BoardUserId);
      _db.Entry(theReply).State = EntityState.Modified;
      try
      {
        Console.WriteLine("BEFORE SAVE\n");
        await _db.SaveChangesAsync();
        Console.WriteLine("AFTER SAVE\n");
      }
      catch (DbUpdateConcurrencyException)
      {
        if (ReplyExists(theReply.ReplyId))
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

    private bool ReplyExists(string replyId)
    {
      return _db.Replies.Any(r => r.ReplyId == replyId);
    }
  }
}
