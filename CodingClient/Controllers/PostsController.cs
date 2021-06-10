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
  public class PostsController : Controller
  {
    [HttpGet("/posts/all")]
    public IActionResult Index()
    {
      var thePost = Post.Get("posts", "all");
      return View(thePost);
    }

    [HttpGet("/posts/{postId}")]
    public IActionResult Details(string postId)
    {
      var thePost = Post.Get("posts", postId);
      return View(thePost);
    }

    [HttpPost("/posts/create")]
    public IActionResult Create(Post newPost)
    {
      Console.WriteLine("\n\nHIT POST CREATE ROUTE. {0}", newPost);
      Console.WriteLine(newPost.Body);
      Post.Create(newPost, newPost.BoardId);
      return RedirectToAction("Index");
    }
  }
}

