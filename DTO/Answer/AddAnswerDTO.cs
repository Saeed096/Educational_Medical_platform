using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Answer
{
    public class AddAnswerDTO
    {
        public string Description { get; set; }

        public bool IsCorrect { get; set; }
    }
}