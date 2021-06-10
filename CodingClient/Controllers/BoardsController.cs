using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodingClient.Models;

namespace CodingClient.Controllers
{
  public class BoardsController : Controller
  {
    [HttpGet("/boards/all")]
    public IActionResult Index()
    {
      var theBoard = Board.Get("boards", "all");
      return View(theBoard);
    }

    [HttpGet("/boards/{boardId}")]
    public IActionResult Details(string boardId)
    {
      var theBoard = Board.Get("boards", boardId);
      return View(theBoard);
    }
  }
}
