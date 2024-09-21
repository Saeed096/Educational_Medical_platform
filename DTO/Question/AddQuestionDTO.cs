using Educational_Medical_platform.DTO.Answer;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Question
{
    public class AddQuestionDTO
    {
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "Description Must be within (3-200) chars")]
        [Required]
        public string Description { get; set; }

        [Required]
        public List<AddAnswerDTO> Answers { get; set; }
    }
}