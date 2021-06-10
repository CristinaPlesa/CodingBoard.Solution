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

    // public static List<Reply> Get(string resource, string id)
    // {
    //   var apiCallTask = ApiHelper.Get(resource, id);
    //   var result = apiCallTask.Result;

    //   JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    //   List<Reply> replyList = JsonConvert.DeserializeObject<List<Reply>>(jsonResponse.ToString());

    //   return replyList;
    // }

    // public static void Post(Reply reply)
    // {
    //   string jsonReply = JsonConvert.SerializeObject(reply);
    //   var apiCallTask = ApiHelper.Post(jsonReply);
    // }

    // public static void Put(Reply reply)
    // {
    //   string jsonReply = JsonConvert.SerializeObject(reply);
    //   var apiCallTask = ApiHelper.Put(reply.ReplyId, jsonReply);
    // }

    // public static void Delete(string resource, string id)
    // {
    //   var apiCallTask = ApiHelper.Delete(resource, id);
    // }
  }
}