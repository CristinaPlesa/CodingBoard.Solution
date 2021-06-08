using System;
using System.Collections.Generic;

namespace GlassBBS.Models
{
  public class Reply
  {
    public Reply()
    {
      ReplyId = Guid.NewGuid().ToString();
    }
    public string ReplyId { get; set; }
    public string Body { get; set; }
    public string BoardUserId { get; set; }
  }
}
