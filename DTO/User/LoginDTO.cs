using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.User
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}