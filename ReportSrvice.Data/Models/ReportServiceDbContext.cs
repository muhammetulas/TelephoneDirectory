using Microsoft.EntityFrameworkCore;

namespace ReportService.Data.Models
{
    public class ReportServiceDbContext : DbContext
    {
        public ReportServiceDbContext(DbContextOptions<ReportServiceDbContext> options) : base(options) { }
        public ReportServiceDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=ReportDatabase;User Id=postgres;Password=123456;");
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }
    }
}
