using System;
using System.Collections.Generic;

namespace GlassBBS.Models
{
  public class BoardPost
  {
    public BoardPost()
    {
      BoardPostId = Guid.NewGuid().ToString();
    }
    public string BoardPostId { get; set; }
    public string PostId { get; set; }
    public string BoardId { get; set; }
    public virtual Post Post { get; set; }
    public virtual Board Board { get; set; }
  }
}
