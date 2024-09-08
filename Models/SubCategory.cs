namespace Educational_Medical_platform.Models
{
    public class SubCategory
    {
        // pk
        public int Id { get; set; }

        // fk
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Course>? Courses { get; set; }
        public List<Book>? Books { get; set; }
        public List<Question>? QuestionBank { get; set; }
    }
}
