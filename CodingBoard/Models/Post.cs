using System.Collections.Generic;
using System;

namespace CodingBoard.Models
{
  public class Post
  {
    public Post()
    {
      PostId = Guid.NewGuid().ToString();
    }
    public string PostId { get; set; }
    public string Body { get; set; }
    public virtual ICollection<Reply> Replies { get; set; }
    public string BoardUserId { get; set; }
    public string BoardId { get; set; }
  }
}
