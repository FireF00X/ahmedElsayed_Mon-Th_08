using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class SignUpViewModel
	{
		[Required(ErrorMessage="First Name is Required")]
		public string FirstName { get; set; }

		[Required(ErrorMessage="Last Name is Required")]
		public string LastName { get; set; }

		[Required(ErrorMessage= "Email is Required")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Email is Required")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{6,}$",
		ErrorMessage = "Password must be at least 6 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one non-alphanumeric character.")]
		public string Password { get; set; }

		[Required(ErrorMessage ="ConFirme your Password")]
		[Compare(nameof(Password),ErrorMessage ="Password doesn't match")]
		public string ConfirmePassword { get; set; }

		[Required(ErrorMessage = "Is Agree Is Required")]
		public bool IsAgree { get; set; }
    }
}
