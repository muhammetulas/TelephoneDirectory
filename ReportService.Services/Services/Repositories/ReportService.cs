using ReportService.Services.Interfaces;
using ReportService.Data.Entities.ApiRequest;
using ReportService.Data.Models;
using TelephoneDirectory.Services.Interfaces;
using TelephoneDirectory.Data.Entities;

namespace ReportService.Services.Repositories
{
    public class ReportService : IReportService
    {
        private readonly IUserService _userService;

        public ReportService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task CreateReport(string location)
        {
            using var context = new ReportServiceDbContext();

            var report = new Report
            {
                RequestedDate = DateTime.UtcNow,
                Status = Data.Helpers.Enums.ReportStatus.Prepared
            };
            context.Reports.Add(report);

            context.SaveChanges();

            await Task.Run(() => PrepareReport(location, report));

        }

        private void PrepareReport(string location, Report report)
        {
            using var context = new ReportServiceDbContext();

            var userDetail = _userService.GetAllUserInformationsData();
            var userDetailByLocation = userDetail.Where(x => x.UserInformationType == TelephoneDirectory.Data.Helpers.Enums.UserInformationTypes.Location && x.InformationContent == location);

            int recordedPhoneNumberCount = 0;

            foreach (var item in userDetailByLocation)
            {
                if(userDetail.Any(x => x.UserId == item.UserId && x.UserInformationType == TelephoneDirectory.Data.Helpers.Enums.UserInformationTypes.PhoneNumber && !string.IsNullOrEmpty(x.InformationContent)))
                {
                    recordedPhoneNumberCount++;
                }
            }

            context.ReportDetails.Add(new ReportDetail
            {
                ReportId = report.Uuid,
                Location = location,
                TotalPhoneNumberCount = recordedPhoneNumberCount,
                TotalUserCount = userDetailByLocation.Count()
            });

            context.SaveChanges();
        }

        public IList<Report> GetAllReports()
        {
            using var context = new ReportServiceDbContext();

            return context.Reports.ToList();
        }

        public ReportDetail GetReportDetail(int reportId)
        {
            throw new NotImplementedException();
        }
    }
}
