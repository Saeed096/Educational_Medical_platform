using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Answer
{
    public class AddAnswerDTO
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }
}