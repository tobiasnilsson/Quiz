using System.Data.Entity;
using Quiz.Web.Models;

namespace Quiz.Web.Infrastructure
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("OneDBToRuleThemAll")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}