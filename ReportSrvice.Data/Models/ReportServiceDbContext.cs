using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ReportService.Data.Models
{
    public class ReportServiceDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ReportServiceDbContext(DbContextOptions<ReportServiceDbContext> options) : base(options) { }
        public ReportServiceDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("MyPostgreSQLDbConnection"));
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }
    }
}
