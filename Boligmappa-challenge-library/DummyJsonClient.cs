using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Boligmappa_challenge_library.JsonContract;

namespace Boligmappa_challenge_library
{
    public class DummyJsonClient
    {
        HttpClient client;

        public DummyJsonClient()
        {
            client = new();
        }

        //Possible improvement by using the pagination information to fetch all objects instead of a sample
        //Uses the JsonNode index to navigate to the object data and discard the pagination information
        public async Task<List<User>> GetAllUsers() =>
            (await GetJsonNodeFromURL("https://dummyjson.com/users"))["users"].Deserialize<List<User>>();

        public async Task<string> GetUserName(int userId) =>
            (await GetJsonNodeFromURL("https://dummyjson.com/users/" + userId + "/?select=username")).Deserialize<User>().Username;
        
        public async Task<List<User>> GetCardTypeUsers(string cardType) =>
            (await GetJsonNodeFromURL("https://dummyjson.com/users/filter?key=bank.cardType&value=" + cardType))["users"].Deserialize<List<User>>();

        public async Task<List<Todo>> GetAllTodos() =>
            (await GetJsonNodeFromURL("https://dummyjson.com/todos/"))["todos"].Deserialize<List<Todo>>();

        public async Task<List<Todo>> GetUserTodos(int userId) =>
            (await GetJsonNodeFromURL("https://dummyjson.com/users/" + userId + "/todos"))["todos"].Deserialize<List<Todo>>();

        public async Task<List<Post>> GetUserPost(int userId) =>
            (await GetJsonNodeFromURL("https://dummyjson.com/users/" + userId + "/posts"))["posts"].Deserialize<List<Post>>();
        
        //maybe limit
        public async Task<List<Post>> GetAllPosts() =>
            (await GetJsonNodeFromURL("https://dummyjson.com/posts"))["posts"].Deserialize<List<Post>>();


        private async Task<JsonNode> GetJsonNodeFromURL(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            return JsonNode.Parse(response.Content.ReadAsStream());
        }
    }
}