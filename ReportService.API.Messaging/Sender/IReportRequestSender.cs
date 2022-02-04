using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.API.Messaging.Sender
{
    public interface IReportRequestSender
    {
        Task SendReportRequest(string location);
    }
}
