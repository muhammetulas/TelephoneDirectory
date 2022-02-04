using System.ComponentModel.DataAnnotations;

namespace ReportService.Data.Models
{
    public class ReportDetail
    {
        [Key]
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string Location { get; set; }
        public int TotalUserCount { get; set; }
        public int TotalPhoneNumberCount { get; set; }
    }
}
