using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TelephoneDirectory.Data.Helpers.Enums;

namespace TelephoneDirectory.Data.Entities.ApiRequest
{
    public class UserInformationRequest
    {
        public int UserId { get; set; }
        public UserInformationTypes UserInformationType { get; set; }
        public string InformationContent { get; set; }
    }
}
