using Boligmappa_challenge_library;
using Boligmappa_challenge_library.DataLayer;
using Boligmappa_challenge_library.JsonContract;

namespace Boligmappa_challenge.Tests;

public class JsonClientTests
{
    [Fact]
    public void CanQueryDummyJsonClient()
    {
        //Check if at least one user is returned
        Assert.True(new DummyJsonClient().GetAllUsers().Result.Count() > 0);
    }
}