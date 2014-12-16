using System.ComponentModel.DataAnnotations;

namespace Rms.Web.Models.Customer
{
    public class UserInfoModel
    {
        [Required(ErrorMessage = "UserInfo.Fields.FirstName.Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "UserInfo.Fields.LastName.Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserInfo.Fields.MobileNumber.Required")]
        public string MobileNumber { get; set; }

        public string Gender { get; set; }

        public string Company { get; set; }
    }
}

