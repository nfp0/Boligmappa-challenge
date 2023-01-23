using Boligmappa_challenge_library.DataLayer;
using Boligmappa_challenge_library.Domain;

namespace Boligmappa_challenge_2nd_app;
class Program
{
    static void Main(string[] args)
    {
        BoligmappaDbContext dbContext = new("BoligmappaMainDB");

        Console.WriteLine("Recreating Database...");
        MigrationsHelper migrationsHelper = new(dbContext);
        migrationsHelper.DeleteDatabase();
        migrationsHelper.ApplyMigrations();
        Console.WriteLine("Finished recreating Database.");

        Console.WriteLine("Populating DB with Post data...");
        PopulateDB populateDB = new(dbContext);
        populateDB.PopulatePostInfo();
        Console.WriteLine("Finished populating DB.");
    }
}
