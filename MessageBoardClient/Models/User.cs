using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace MessageBoardClient.Models
{
  public class User
  {
    public int UserId { get; set; }
    public string UserName { get; set; }
    public DateTime CreationDate { get; set; }
    public ICollection<Post> UserPosts { get; set; }
    public ICollection<Thread> UserThreads { get; set; }
    public User()
    {
      this.UserPosts = new HashSet<Post>();
      this.UserThreads = new HashSet<Thread>();
    }
    public static List<User> GetUsers()
    {
      string requestAddress = "Users";
      var apiCallTask = apiHelper.GetAll(requestAddress);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<User> userList = JsonConvert.DeserializeObject<List<User>>(jsonResponse.ToString());

      return userList;
    }

    public static User GetDetails(int id)
    {
      string requestAddress = $"Users/{id}";
      var apiCallTask = ApiHelper.Get(requestAddress);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      User user = JsonConvert.DeserializeObject<User>(jsonResponse.ToString());
      return user;
    }

    public static void Post(User user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = ApiHelper.Post(jsonUser);
    }

    public static void Put(User user)
    {
      string jsonUser = jsonConvert.SerializeObject(user);
      var apiCallTask = ApiHelper.Put(user.UserId, jsonuser);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}