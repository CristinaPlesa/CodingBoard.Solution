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
    public ActionResult<IEnumerable<BoardPost>> Posts(string BoardId)
    {
      Console.WriteLine("HIT BOARD {0} /POSTS", BoardId);
      var thePosts = _db.BoardPosts.Where(b => b.BoardId == BoardId).Include(join => join.Post).Where(bp => bp.BoardId == BoardId);
      return thePosts.ToList();
    }
  }
}
