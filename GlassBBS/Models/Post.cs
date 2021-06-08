using System.Collections.Generic;
using System;

namespace GlassBBS.Models
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
    public string PostAuthorId { get; set; }
    public string BoardId { get; set; }
  }
}
