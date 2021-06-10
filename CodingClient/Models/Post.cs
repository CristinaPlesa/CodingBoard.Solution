using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodingClient.Models
{
  public class Post
  {
    public string PostId { get; set; }
    public string Body { get; set; }
    public virtual ICollection<Reply> Replies { get; set; }
    public string BoardUserId { get; set; }
    public string BoardId { get; set; }
    public int VoteCount { get; set; }
    public static List<Post> Get(string resource, string id)
    {
      var apiCallTask = ApiHelper.Get(resource, id);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonResponse.ToString());

      return postList;
    }

    public static void Create(Post post, string boardId)
    {
      Console.WriteLine("HIT POST MODEL CREATE METHOD {0} {1} {2}", post.Body, post.BoardUserId, boardId);
      string jsonPost = JsonConvert.SerializeObject(post);
      Console.WriteLine("AFTER JSONPOST {0}", jsonPost);
      var apiCallTask = ApiHelper.Post(jsonPost, "posts", boardId);
    }

    // public static void Put(Post post)
    // {
    //   string jsonPost = JsonConvert.SerializeObject(post);
    //   var apiCallTask = ApiHelper.Put(post.PostId, jsonPost);
    // }

    // public static void Delete(string resource, string id)
    // {
    //   var apiCallTask = ApiHelper.Delete(resource, id);
    // }
  }
}
