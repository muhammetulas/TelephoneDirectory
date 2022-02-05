using Microsoft.AspNetCore.Mvc;
using ReportService.API.Messaging.Sender;
using ReportService.Services.Interfaces;
using ReportService.Data.Entities.ApiRequest;
using ReportService.Data.Models;

namespace ReportService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IReportRequestSender _reportRequestSender;

        public ReportController(IReportService reportService, IReportRequestSender reportRequestSender)
        {
            _reportService = reportService;
            _reportRequestSender = reportRequestSender;
        }

        [HttpPost("create-report")]
        public async Task<IActionResult> CreateReport(string location)
        {
            await _reportService.CreateReport(location);

            return Ok("Success");
        }

        [HttpGet("get-reports")]
        public IActionResult GetAllReports()
        {
            return Ok(_reportService.GetAllReports());
        }

        [HttpGet("get-report-details")]
        public IActionResult GetReportDetails(int reportId)
        {
            return Ok(_reportService.GetReportDetail(reportId));
        }
    }
}
