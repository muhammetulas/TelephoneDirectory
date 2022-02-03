using Microsoft.EntityFrameworkCore;
using TelephoneDirectory.Data.Entities;

namespace TelephoneDirectory.Data.Models
{
    public class TelephoneDirectoryContext : DbContext
    {
        public TelephoneDirectoryContext(DbContextOptions<TelephoneDirectoryContext> options) : base(options) { }
        public TelephoneDirectoryContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=telephoneDirectory;User Id=postgres;Password=123456;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
    }
}
