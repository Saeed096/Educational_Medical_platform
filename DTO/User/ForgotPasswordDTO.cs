using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.User
{
    public class ForgotPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
