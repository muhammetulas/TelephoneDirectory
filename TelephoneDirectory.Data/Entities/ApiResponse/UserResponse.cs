using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory.Data.Entities.ApiResponse
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FirmName { get; set; }
        public IList<UserInformation> UserInformations { get; set; }

        public UserResponse()
        {
            this.UserInformations = new List<UserInformation>();
        }
    }
}
