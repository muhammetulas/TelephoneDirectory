using AutoMapper;
using Moq;
using ReportService.API.Messaging.Sender;
using ReportService.Controllers;
using ReportService.Data.Models;
using ReportService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ReportService.Test
{
    public class ReportServiceControllerTest
    {
        readonly Mock<IReportService> mockReportService;
        readonly Mock<IReportRequestSender> mockReportRequestSender;

        public ReportServiceControllerTest()
        {
            mockReportRequestSender = new Mock<IReportRequestSender>();
            mockReportService = new Mock<IReportService>();
        }

        public object Datetime { get; private set; }

        [Fact]
        public async Task WhenCreateReportReturnSuccess()
        {
            var reportController = new ReportController(mockReportService.Object, mockReportRequestSender.Object);

            mockReportService.Setup(x => x.CreateReport(It.IsAny<string>()));

            var response = await reportController.CreateReport("TestLocation");

            Assert.NotNull(response);
        }

        [Fact]
        public void WhenGetAllReportListShouldNotNull()
        {
            var reportController = new ReportController(mockReportService.Object, mockReportRequestSender.Object);

            var response = new List<Report>();
            response.Add(new Report
            {
                RequestedDate = DateTime.Now,
                Status = Data.Helpers.Enums.ReportStatus.Completed
            });

            mockReportService.Setup(x => x.GetAllReports()).Returns(response);

            var controllerResponse = reportController.GetAllReports();

            Assert.NotNull(controllerResponse);
        }

        [Fact]
        public void WhenGetReportDetailShouldNotNull()
        {
            var reportController = new ReportController(mockReportService.Object, mockReportRequestSender.Object);

            mockReportService.Setup(x => x.GetReportDetail(It.IsAny<int>())).Returns(new ReportDetail
            {
                Location = "TestLocation",
                ReportId = 1,
                TotalPhoneNumberCount = 100,
                TotalUserCount = 100
            });

            var controllerResponse = reportController.GetReportDetails(1500);

            Assert.NotNull(controllerResponse);
        }
    }
}