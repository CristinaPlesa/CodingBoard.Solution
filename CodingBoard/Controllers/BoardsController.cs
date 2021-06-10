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

    [HttpGet("/api/boards/all")]
    public ActionResult<IEnumerable<Board>> Boards()
    {
      return _db.Boards.ToList();
    }

    [HttpGet("/api/boards/{boardId}")]
    public ActionResult<IEnumerable<Board>> GetBoardBy(string boardId)
    {
      Console.WriteLine("HIST API/BOARDS/BOARDID");
      return _db.Boards.Where(entry => entry.BoardId == boardId).ToList();
    }
  }
}
