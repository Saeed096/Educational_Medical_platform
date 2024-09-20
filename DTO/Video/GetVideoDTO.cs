using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.DTO.Video
{
    public class GetVideoDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }    // no of video in this course videos 
        public string Title { get; set; }
        public string? ThumbnailURL { get; set; }
        public string? Description { get; set; }
        public string videoURL { get; set; }
        public int CourseId { get; set; }
    }
}
