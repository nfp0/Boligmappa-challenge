using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Boligmappa_challenge_library.DataLayer
{
    public class BoligmappaDbContext : DbContext
    {
        public DbSet<UserTotals> UserTotals { get; set; }
        public DbSet<PostInfo> PostInfo { get; set; }

        string databaseName;

        public BoligmappaDbContext(string databaseName) => this.databaseName = databaseName;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=" + databaseName + ";Username=nuno");
    }

    public class UserTotals
    {
        [Key]
        public int UserId { get; set; }
        public int NrPosts { get; set; }
        public int NrToDos { get; set; }
    }


    public class PostInfo
    {
        [Key]
        public int PostId { get; set; }
        public string UserName { get; set; }
        public bool HasFrenchTag { get; set; }
        public bool HasFictionTag { get; set; }
        public bool HasMoreThanTwoReactions { get; set; }
    }
}