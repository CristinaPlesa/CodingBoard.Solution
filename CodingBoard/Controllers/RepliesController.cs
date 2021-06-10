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

    [HttpGet("/api/replies/{postId}")]
    public ActionResult<IEnumerable<Reply>> Replies(string postId)
    {
      Post post = _db.Posts.FirstOrDefault(p => p.PostId == postId);
      return post.Replies.ToList();
    }

    [HttpPost("/api/replies/{postId}")]
    public async Task<ActionResult<Reply>> NewReply(string body, string boardUserId, string postId)
    {
      Console.WriteLine("HIT POST NEW REPLY");
      Reply newReply = new() { Body = body, BoardUserId = boardUserId, PostId = postId, VoteCount = 0 };
      _db.Replies.Add(newReply);
      await _db.SaveChangesAsync();
      return CreatedAtAction("NewReply", new { id = newReply.ReplyId }, newReply);
    }

    [HttpDelete("/api/replies/{replyId}")]
    public async Task<IActionResult> DeleteReply(string replyId)
    {
      Reply thisReply = _db.Replies.FirstOrDefault(r => r.ReplyId == replyId);
      _db.Replies.Remove(thisReply);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("/api/replies/{replyId}")]
    public async Task<IActionResult> EditReply(Reply theReply)
    {
      Console.WriteLine("HIT PUT edit REPLIES ROUTE. replyId: {0} \t body {1} \t board user id {2}", theReply.ReplyId, theReply.Body, theReply.BoardUserId);
      _db.Entry(theReply).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
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

    [HttpPost("/api/vote/{replyId}")]
    public async Task<IActionResult> Vote(string replyId, string upOrDown)
    {
      Reply thisReply = _db.Replies.FirstOrDefault(r => r.ReplyId == replyId);
      if (upOrDown == "up")
      {
        thisReply.VoteCount++;
      }
      else
      {
        thisReply.VoteCount--;
      }
      await _db.SaveChangesAsync();
      return NoContent();
    }

    private bool ReplyExists(string replyId)
    {
      return _db.Replies.Any(r => r.ReplyId == replyId);
    }
  }
}
