using System.ComponentModel.DataAnnotations;
using static ReportService.Data.Helpers.Enums;

namespace ReportService.Data.Models
{
    public class Report
    {
        [Key]
        public int Uuid { get; set; }
        public DateTime RequestedDate { get; set; }
        public ReportStatus Status { get; set; }
    }
}
