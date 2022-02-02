using Microsoft.EntityFrameworkCore;
using TelephoneDirectory.Data.Entities;

namespace TelephoneDirectory.Data.Models
{
    public class TelephoneDirectoryContext : DbContext
    {
        public TelephoneDirectoryContext(DbContextOptions<TelephoneDirectoryContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
    }
}
