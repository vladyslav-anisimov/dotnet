using System.ComponentModel.DataAnnotations;

namespace dotnet.Models
{
    public class LoginView
    {
        [Required(ErrorMessage = "Email required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }
    }
}
