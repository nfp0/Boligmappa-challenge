using System.Collections.Generic;
using System.Linq;
using Boligmappa_challenge_library.JsonContract;

namespace Boligmappa_challenge_library.Domain
{
    public class TodoQueries
    {
        public List<Todo> GetTodosFromUsersWithMoreThanXPosts(int nrOfPosts)
        {
            DummyJsonClient client = new();

            //Possible improvements by fetching all UserTodos beforehand, depending on how big the dataset is
            return client.GetAllPosts().Result
                .GroupBy(post => post.UserId)
                .Where(group => group.Count() > nrOfPosts)
                .Select(group => group.Key)
                .SelectMany(userId => client.GetUserTodos(userId).Result)
                .ToList();
        }
    }
}