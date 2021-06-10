using Newtonsoft.Json;
using Newtonson.Linq;
using System.Collections.Generic;
using System;

namespace CodingClient.Models
{
  public class Board
  {
    public string BoardId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
  }
}
