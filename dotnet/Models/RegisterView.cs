using System.ComponentModel.DataAnnotations;

namespace dotnet.Models
{
    public class RegisterView
    {
        [Required(ErrorMessage = "Email required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email error.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password error.")]
        public string ConfirmPassword { get; set; }
    }
}
