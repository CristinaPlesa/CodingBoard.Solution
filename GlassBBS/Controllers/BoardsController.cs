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
  }
}
