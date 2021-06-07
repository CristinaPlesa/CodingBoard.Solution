using System;
using System.Collections.Generic;

namespace GlassBBS.Models
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
    public virtual ICollection<BoardPost> BoardPosts { get; set; }
  }
}
