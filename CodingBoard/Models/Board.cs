using System.Collections.Generic;
using System;

namespace CodingBoard.Models
{
  public class Board
  {
    public Board()
    {
      BoardId = Guid.NewGuid().ToString();
    }
    public string BoardId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
  }
}
