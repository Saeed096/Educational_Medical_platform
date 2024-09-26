using Educational_Medical_platform.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.User
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Address")]
        [StringLength(254, ErrorMessage = "Email cannot be longer than 254 characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid Phone Number. Format: +[country code][number] (e.g., +1234567890).")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public Role Role { get; set; }
    }
}