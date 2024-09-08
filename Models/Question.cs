namespace Educational_Medical_platform.Models
{
    public class Question
    {
        // 1ry key
        public int Id { get; set; }

        // fk
        public int? TestId { get; set; }
        public StandardTest? Test { get; set; }

        public int? SubCategoryId { get; set; }  // nullable as this question may not be related to any question bank but related to course questions 
        public SubCategory? SubCategory { get; set; }

        public int? CourseId { get; set; } 
        public Course? Course  { get; set; }

        public int? BlogId { get; set; } 
        public Blog? Blog { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
