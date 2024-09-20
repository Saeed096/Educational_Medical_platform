using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.DTO.Video
{
    public class AddVideoDTO
    {
        public int Number { get; set; }    // no of video in this course videos 
        public string Title { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public string? Description { get; set; }
        public IFormFile? video { get; set; }
        public int CourseId { get; set; }
    }
}
