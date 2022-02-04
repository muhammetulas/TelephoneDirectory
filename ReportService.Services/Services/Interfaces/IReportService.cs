using ReportService.Data.Entities.ApiRequest;
using ReportService.Data.Models;

namespace ReportService.Services.Interfaces
{
    public interface IReportService
    {
        Task AddDetail(DetailNotificationRequest reportDetail);
        Task DeleteDetail(int detailId);
        Task CreateReport(string location);
        Task<List<Report>> GetAllReports();
        Task<ReportDetail> GetReportDetail(int reportId);
    }
}
