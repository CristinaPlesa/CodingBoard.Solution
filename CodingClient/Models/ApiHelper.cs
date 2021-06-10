using System;
using System.Threading.Tasks;
using RestSharp;

namespace CodingClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> Get(string resource, string id)
    {
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newPost, string resource, string id)
    {
      Console.WriteLine("\n\nHIT CLIENT APIHELPER method POST: {0} {1} {2}", newPost, resource, id);
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}/", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      Console.WriteLine("REQUEST: {0}", request.ToString());
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(string newPost, string resource, string id)
    {
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task<string> Delete(string resource, string id)
    {
      RestClient client = new("http://localhost:5000/api");
      RestRequest request = new($"{resource}/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}
