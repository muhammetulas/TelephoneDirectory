using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TelephoneDirectory.Data.Entities;

namespace TelephoneDirectory.Data.Models
{
    public class TelephoneDirectoryContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TelephoneDirectoryContext(DbContextOptions<TelephoneDirectoryContext> options) : base(options) { }
        public TelephoneDirectoryContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("MyPostgreSQLDbConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
    }
}
