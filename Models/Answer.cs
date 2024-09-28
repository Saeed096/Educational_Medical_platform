using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Reason { get; set; }

        public bool IsCorrect { get; set; }

        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}