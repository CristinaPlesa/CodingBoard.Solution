using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodingClient.Models
{
  public class Reply
  {
    // public Reply()
    // {
    //   ReplyId = Guid.NewGuid().ToString();
    //   VoteCount = 0;
    // }
    public string ReplyId { get; set; }
    public string Body { get; set; }
    public string BoardUserId { get; set; }
    public string PostId { get; set; }
    public int VoteCount { get; set; }
  }
}
