using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Question
    {
        // 1ry key
        [Key]
        public int Id { get; set; }

        // fk
        [ForeignKey("Test")]

        public int? TestId { get; set; }
        public StandardTest? Test { get; set; }
        [ForeignKey("SubCategory")]

        public int? SubCategoryId { get; set; }  // nullable as this question may not be related to any question bank but related to course questions 
        public SubCategory? SubCategory { get; set; }
        [ForeignKey("Course")]

        public int? CourseId { get; set; } 
        public Course? Course  { get; set; }
        [ForeignKey("Blog")]

        public int? BlogId { get; set; } 
        public Blog? Blog { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
