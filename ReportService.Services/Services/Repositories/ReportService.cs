using ReportService.Services.Interfaces;
using ReportService.Data.Entities.ApiRequest;
using ReportService.Data.Models;

namespace ReportService.Services.Repositories
{
    public class ReportService : IReportService
    {
        public Task AddDetail(DetailNotificationRequest reportDetail)
        {
            throw new NotImplementedException();
        }

        public Task CreateReport(string location)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDetail(int detailId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Report>> GetAllReports()
        {
            using var context = new ReportServiceDbContext();

            return context.Reports.ToList();
        }

        public Task<ReportDetail> GetReportDetail(int reportId)
        {
            throw new NotImplementedException();
        }
    }
}
