using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlassBBS.Models;

namespace GlassBBS.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BoardsController : ControllerBase
  {
    private readonly GlassBBSContext _db;

    public BoardsController(GlassBBSContext db)
    {
      _db = db;
    }

    [HttpGet("/api/boards")]
    public ActionResult<IEnumerable<Board>> Boards()
    {
      return _db.Boards.ToList();
    }

    [HttpGet("/api/board/{Name}")]
    public ActionResult<IEnumerable<Board>> GetBoardBy(string Name)
    {
      return _db.Boards.Where(entry => entry.Name == Name).ToList();
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
      Console.WriteLine("HIT POST NEW POST ROUTE {0} {1} {2}", boardId, body, postAuthorId);
      Post newPost = new() { Body = body, PostAuthorId = postAuthorId, BoardId = boardId };
      Console.WriteLine("NEW POST GENERATED {0}", newPost);
      _db.Posts.Add(newPost);
      Console.WriteLine("AFTER ADD");
      await _db.SaveChangesAsync();
      Console.WriteLine("AFTER SAVE...");
      return CreatedAtAction("NewPost", new { id = newPost.PostId }, newPost);

    }
  }
}


// '00da967a-652d-4c9d-b9ef-f1bea2111d1d','Residencies','Information regarding various residency opportunities.'
// '227c89ae-57c0-4c71-ae95-8c8be11d511d','Workshops','A selection of educational workshop offerings.'
// '2d993c3d-72d7-491f-97dc-3c38cfbcbb8e','Education','A list of institutions offering higher-ed degrees in the field.'
// '68fb0ed7-d268-438c-859c-0f83cfe99dc4','Jobs','Find relevant job info within the field.'
// '9dd9f397-76d8-41d6-8232-9fe67a09add2','Scholarships','Scholarship info for workshops and universities.'
// 'e08c3b28-bcfa-4040-97fc-7acdf10328c7','Exhibitions','View selected works/exhibitions by various artists'

