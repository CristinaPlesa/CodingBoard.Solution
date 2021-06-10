using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Ling;

namespace CodingClient.Models
{
  public class Post
  {
    // public Post()
    // {
    //   PostId = Guid.NewGuid().ToString();
    //   VoteCount = 0;
    // }
    public string PostId { get; set; }
    public string Body { get; set; }
    public virtual ICollection<Reply> Replies { get; set; }
    public string BoardUserId { get; set; }
    public string BoardId { get; set; }
    public int VoteCount { get; set; }
  }
}
