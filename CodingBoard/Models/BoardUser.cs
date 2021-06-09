using System;
using System.Collections.Generic;

namespace CodingBoard.Models
{
  public class BoardUser
  {
    public BoardUser()
    {
      BoardUserId = Guid.NewGuid().ToString();
    }

    public string BoardUserId { get; set; }
    public string Name { get; set; }
  }
}
