using System.ComponentModel.DataAnnotations;

namespace TelephoneDirectory.Data.Entities
{
    public class User
    {
        [Key]
        public int Uuid { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FirmName { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
