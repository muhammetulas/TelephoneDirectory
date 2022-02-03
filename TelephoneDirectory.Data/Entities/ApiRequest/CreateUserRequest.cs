using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory.Data.Entities.ApiRequest
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FirmName { get; set; }
        public IList<UserInformationRequest> UserInformations { get; set; }

        public CreateUserRequest()
        {
            this.UserInformations = new List<UserInformationRequest>();
        }
    }
}
