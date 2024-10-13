using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Models
{
    public class StandardTest
    {
        // 1ry key
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fullmark { get; set; }

        // can be ignored and handdled in front >> min foreach question 
        public int DurationInMinutes { get; set; }

        public List<Question> Question { get; set; }
    }
}