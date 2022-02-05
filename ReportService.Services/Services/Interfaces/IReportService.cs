using ReportService.Data.Entities.ApiRequest;
using ReportService.Data.Models;

namespace ReportService.Services.Interfaces
{
    public interface IReportService
    {
        Task CreateReport(string location);
        IList<Report> GetAllReports();
        ReportDetail GetReportDetail(int reportId);
    }
}
