using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TelephoneDirectory.Data.Helpers.Enums;

namespace TelephoneDirectory.Data.Entities
{
    public class UserInformation
    {
        [Key]
        public int InformationId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public UserInformationTypes UserInformationType { get; set; }
        public string InformationContent { get; set; }
    }
}
