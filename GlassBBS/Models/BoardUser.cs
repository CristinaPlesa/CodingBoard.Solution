using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GlassBBS.Models
{
  public class BoardUser : IdentityUser
  {
    public BoardUser()
    {
      BoardUserId = Guid.NewGuid().ToString();
      BoardPosts = new HashSet<BoardPost>();
      PostReplies = new HashSet<PostReply>();
    }

    public string BoardUserId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BoardPost> BoardPosts { get; set; }
    public virtual ICollection<PostReply> PostReplies { get; set; }
  }
}
