using Microsoft.EntityFrameworkCore;

namespace Boligmappa_challenge_library.DataLayer
{
    public class MigrationsHelper
    {
        BoligmappaDbContext dbContext;
        public MigrationsHelper(BoligmappaDbContext dbContext) => this.dbContext = dbContext;

        //Use .NET migrations to generate a code-first database
        public void ApplyMigrations() => dbContext.Database.Migrate();
        public void DeleteDatabase() => dbContext.Database.EnsureDeleted();
    }
}