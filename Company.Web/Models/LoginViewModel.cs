using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Is Agree Is Required")]
        public bool IsAgree { get; set; }
    }
}
