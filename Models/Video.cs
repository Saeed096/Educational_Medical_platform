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

        //public string? ThumbnailURL { get; set; }

        //[NotMapped]
        //public IFormFile? Thumbnail { get; set; }

        public string? Description { get; set; }

        public string? videoURL { get; set; }

        [NotMapped]
        public IFormFile? video { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        // not valuable from saeed opinion
        //public string Size { get; set; }
        //public string Type { get; set; }
    }
}
