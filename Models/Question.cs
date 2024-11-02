using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "Description Must be within (3-200) chars")]
        public string Description { get; set; }

        [ForeignKey(nameof(Test))]
        public int? TestId { get; set; }

        public StandardTest? Test { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public int? SubCategoryId { get; set; }  // nullable as this question may not be related to any question bank but related to course questions 
       
        public SubCategory? SubCategory { get; set; }

        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; } 
       
        public Course? Course  { get; set; }

        [ForeignKey(nameof(Blog))]
        public int? BlogId { get; set; } 
       
        public Blog? Blog { get; set; }

        public List<Answer> Answers { get; set; }
    }
}