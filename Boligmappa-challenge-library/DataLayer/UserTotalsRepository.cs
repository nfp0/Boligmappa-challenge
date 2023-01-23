using System.Collections.Generic;
using System.Linq;

namespace Boligmappa_challenge_library.DataLayer
{
    public class UserTotalsRepository
    {
        BoligmappaDbContext dbContext;

        public UserTotalsRepository(BoligmappaDbContext dbContext) => this.dbContext = dbContext;

        public void InsertUserTotalsRange(List<UserTotals> userTotals)
        {
            dbContext.AddRange(userTotals);
            dbContext.SaveChanges();
        }

        public UserTotals GetUserTotals(int id) => dbContext.UserTotals.Find(id);
        public List<UserTotals> GetAllUserTotals() => dbContext.UserTotals.ToList();
    }
}
