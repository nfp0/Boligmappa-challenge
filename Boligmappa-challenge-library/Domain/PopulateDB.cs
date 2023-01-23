
using System.Collections.Generic;
using System.Linq;
using Boligmappa_challenge_library.DataLayer;
using Boligmappa_challenge_library.JsonContract;

namespace Boligmappa_challenge_library.Domain
{
    public class PopulateDB
    {
        DummyJsonClient client = new();

        BoligmappaDbContext dbContext;

        public PopulateDB(BoligmappaDbContext dbContext) => this.dbContext = dbContext;

        public void PopulateUserTotals()
        {
            //Possible improvements by filtering only required properties
            List<int> allUserIds = client.GetAllUsers().Result
                .Select(user => user.Id)
                .ToList();

            List<Todo> allTodos = client.GetAllTodos().Result;

            List<Post> filteredPosts = client.GetAllPosts().Result
                .Where(post => post.Reactions > 0 && post.Tags.Any(tag => tag == "history"))
                .ToList();

            List<UserTotals> userTotals = allUserIds.Select(userId =>
                new UserTotals()
                {
                    UserId = userId,
                    NrPosts = filteredPosts.Count(post => post.UserId == userId),
                    NrToDos = allTodos.Count(todo => todo.UserId == userId)
                })
                .ToList();

            new UserTotalsRepository(dbContext).InsertUserTotalsRange(userTotals);
        }

        public void PopulatePostInfo()
        {
            //Possible improvements by fetching all UserNames beforehand, depending on how big the dataset is
            List<PostInfo> postsInfo = client.GetAllPosts().Result
                .Select(post => new PostInfo()
                {
                    PostId = post.Id,
                    UserName = client.GetUserName(post.UserId).Result,
                    HasFictionTag = post.Tags.Any(tag => tag == "fiction"),
                    HasFrenchTag = post.Tags.Any(tag => tag == "french"),
                    HasMoreThanTwoReactions = post.Reactions > 2
                }).ToList();
            
            new PostInfoRepository(dbContext).InsertPostInfoRange(postsInfo);
        }
    }
}