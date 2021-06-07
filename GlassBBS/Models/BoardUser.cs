using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GlassBBS.Models
{
  public class BoardUser : IdentityUser
  {
    public BoardUser() : base()
    {
      BoardPosts = new HashSet<BoardPost>();
      PostReplies = new HashSet<PostReply>();
    }

    public virtual ICollection<BoardPost> BoardPosts { get; set; }
    public virtual ICollection<PostReply> PostReplies { get; set; }
  }
}
