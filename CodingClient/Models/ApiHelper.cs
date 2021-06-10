using System.Threading.Tasks;
using RestSharp;

namespace CodingClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> Get(string resource, string id, string route)
    {
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}/{route}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newPost, string resource, string id, string action)
    {
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}/{action}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(string newPost, string resource, string id, string action)
    {
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}/{action}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> Delete(string resource, string id, string route)
    {
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}/{route}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}
