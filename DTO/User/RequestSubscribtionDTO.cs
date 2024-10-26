using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.User
{
    public class RequestSubscribtionDTO
    {
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "TransactionImage is required")]
        public IFormFile TransactionImage { get; set; }
    }
}