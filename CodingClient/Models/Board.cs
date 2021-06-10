using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public static List<Board> Get(string resource, string id)
    {
      var apiCallTask = ApiHelper.Get(resource, id);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Board> boardList = JsonConvert.DeserializeObject<List<Board>>(jsonResponse.ToString());

      return boardList;
    }
  }
}
