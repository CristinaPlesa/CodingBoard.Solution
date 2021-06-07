using System;
using System.Collections.Generic;

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
    public virtual ICollection<PostReply> PostReplies { get; set; }
    public virtual BoardUser PostAuthor { get; set; }
  }
}
