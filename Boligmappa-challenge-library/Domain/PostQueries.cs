using System.Collections.Generic;
using System.Linq;
using Boligmappa_challenge_library.JsonContract;

namespace Boligmappa_challenge_library.Domain
{
    public class PostQueries
    {
        public List<Post> GetPostsFromCardTypeUsers(string cardType)
        {
            DummyJsonClient client = new();

            return client.GetCardTypeUsers(cardType).Result
                .SelectMany(user => client.GetUserPost(user.Id).Result)
                .ToList();
        }
    }
}