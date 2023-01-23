using Boligmappa_challenge_library.DataLayer;

namespace Boligmappa_challenge.Tests;

public class DataLayerTests
{
    BoligmappaDbContext dbContext = new BoligmappaDbContext("BoligmappaTestsDB");

    public DataLayerTests()
    {
        //Reset database for tests
        MigrationsHelper migrationsHelper = new(dbContext);
        migrationsHelper.DeleteDatabase();
        migrationsHelper.ApplyMigrations();
    }

    [Fact]
    public void CanInsertUserTotals()
    {
        UserTotalsRepository repository = new(dbContext);

        List<UserTotals> mockUserTotalsList = new()
        {
            new()
            {
                UserId = 1,
                NrPosts = 3,
                NrToDos = 7
            },
            new()
            {
                UserId = 45,
                NrPosts = 93,
                NrToDos = 3
            },
            new()
            {
                UserId = 73,
                NrPosts = 4,
                NrToDos = 88
            }
        };

        repository.InsertUserTotalsRange(mockUserTotalsList);

        Assert.Equal(3, repository.GetAllUserTotals().Count());
        Assert.Equal(7, repository.GetUserTotals(1).NrToDos);
        Assert.Equal(93, repository.GetUserTotals(45).NrPosts);
    }

    [Fact]
    public void CanInsertPostInfo()
    {
        PostInfoRepository repository = new(dbContext);

        List<PostInfo> mockPostInfoList = new()
        {
            new()
            {
                PostId = 50,
                UserName = "Nuno",
                HasFictionTag = true,
                HasFrenchTag = false,
                HasMoreThanTwoReactions = true
            },
            new()
            {
                PostId = 72,
                UserName = "Samus",
                HasFictionTag = false,
                HasFrenchTag = true,
                HasMoreThanTwoReactions = false
            }
        };

        repository.InsertPostInfoRange(mockPostInfoList);

        Assert.Equal(2, repository.GetAllPostInfo().Count());
        Assert.True(repository.GetPostInfo(50).HasFictionTag);
        Assert.False(repository.GetPostInfo(72).HasMoreThanTwoReactions);
    } 
}