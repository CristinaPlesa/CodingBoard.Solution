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
  public class BoardsController : ControllerBase
  {
    private readonly CodingBoardContext _db;

    public BoardsController(CodingBoardContext db)
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
  }
}
