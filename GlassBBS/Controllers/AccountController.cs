using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GlassBBS.ViewModels;
using GlassBBS.Models;

namespace GlassBBS.Controllers
{
  [AllowAnonymous]
  public class AccountController : Controller
  {
    private readonly UserManager<BoardUser> _userManager;
    private readonly SignInManager<BoardUser> _signInManager;
    public AccountController(UserManager<BoardUser> UserManager, SignInManager<BoardUser> SignInManager)
    {
      _userManager = UserManager;
      _signInManager = SignInManager;
    }

    [HttpGet("/account/register")] public ActionResult Register() => View();

    [HttpPost("/account/register")]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var newUser = new BoardUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);
      Console.WriteLine("RESULT FROM SAVE NEW USER: {0}", result);
      return Content(result.ToString());
    }
  }
}
