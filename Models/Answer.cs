namespace Educational_Medical_platform.Models
{
    public class Answer
    {
        // pk
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        // fk
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
