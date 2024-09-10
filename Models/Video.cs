using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Video
    {
        // 1ry key
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }    // no of video in this course videos 
        public string Title { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public string? Description { get; set; }
        public IFormFile video { get; set; }

        [ForeignKey("Course")]

        public int CourseId { get; set; }
        public Course Course { get; set; }

        // not valuable from saeed opinion
        //public string Size { get; set; }
        //public string Type { get; set; }
    }
}
