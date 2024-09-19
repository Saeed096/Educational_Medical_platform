using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.DTO.Answer
{
    public class GetAnswerDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
