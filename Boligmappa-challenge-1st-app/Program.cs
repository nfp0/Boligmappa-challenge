using Boligmappa_challenge_library.DataLayer;
using Boligmappa_challenge_library.Domain;

namespace Boligmappa_challenge_1st_app;
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

        Console.WriteLine("Populating DB with User Data filtered by posts with at least one reaction and with a history tag...");
        PopulateDB populateDB = new(dbContext);
        populateDB.PopulateUserTotals();
        Console.WriteLine("Finished populating DB.");

        Console.WriteLine("Querying and printing Todos of Users with more than 2 posts:");
        new TodoQueries()
            .GetTodosFromUsersWithMoreThanXPosts(2)
            .ForEach(todo => Console.WriteLine(todo.TodoMessage));

        Console.WriteLine("Querying and printing Posts of Users that use Mastercard:");
        new PostQueries()
            .GetPostsFromCardTypeUsers("mastercard")
            .ForEach(post => Console.WriteLine(post.Body));
    }
}
