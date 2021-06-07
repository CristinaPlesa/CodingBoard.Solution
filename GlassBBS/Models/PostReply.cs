using System;
using System.Collections.Generic;

namespace GlassBBS.Models
{
  public class PostReply
  {
    public PostReply()
    {
      PostReplyId = Guid.NewGuid().ToString();
    }
    public string PostReplyId { get; set; }
    public string PostId { get; set; }
    public string ReplyId { get; set; }
    public virtual Post Post { get; set; }
    public virtual Reply Reply { get; set; }
  }
}
