using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.User
{
    public class UpdateUserDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string? UserName { get; set; } 

        public string? NewPassword { get; set; }

        [Compare("NewPassword")]
        public string? ConfirmNewPassword { get; set; } 

        public IFormFile? Image { get; set; }
    }
}