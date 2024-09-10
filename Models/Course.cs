using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Course
    {
        // pk 
        [Key]
        public int Id { get; set; } 
        public String Title { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public float DurationInhours { get; set; } 
        public string? Preview { get; set; } 
        public List<Requirement>? Requirements { get; set; }
        public List<Objective>? Objectives { get; set; }
        public List<Video> Videos { get; set; }
        public List<Question>? Questions { get; set; }
        // fk
        [ForeignKey("SubCategory")]

        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

    }
}
