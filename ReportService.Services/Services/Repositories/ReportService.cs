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

        public Task<List<Report>> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public Task<ReportDetail> GetReportDetail(int reportId)
        {
            throw new NotImplementedException();
        }
    }
}
