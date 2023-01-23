using System;
using System.Collections.Generic;
using System.Linq;

namespace Boligmappa_challenge_library.DataLayer
{
    public class PostInfoRepository
    {
        BoligmappaDbContext dbContext;

        public PostInfoRepository(BoligmappaDbContext dbContext) => this.dbContext = dbContext;

        public void InsertPostInfoRange(List<PostInfo> postInfo)
        {
            dbContext.AddRange(postInfo);
            dbContext.SaveChanges();
        }

        public PostInfo GetPostInfo(int id) => dbContext.PostInfo.Find(id);

        public List<PostInfo> GetAllPostInfo() => dbContext.PostInfo.ToList();
    }
}
