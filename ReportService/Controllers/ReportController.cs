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

        [HttpGet]
        public Task<List<Report>> Get()
        {
            return _reportService.GetAllReports();
        }

        [HttpGet("{id}")]
        public Task<ReportDetail> Get(int id)
        {
            return _reportService.GetReportDetail(id);
        }


        [HttpPost]
        public async Task Post(string location)
        {
            await _reportRequestSender.SendReportRequest(location);
        }

        [HttpPost, Route("add-detail")]
        public async Task AddDetail([FromBody] DetailNotificationRequest detailNotificationRequest)
        {
            await _reportService.AddDetail(detailNotificationRequest);
        }

        [HttpDelete("delete-detail/{id}")]
        public async Task DeleteDetail(int id)
        {
            await _reportService.DeleteDetail(id);
        }
    }
}
