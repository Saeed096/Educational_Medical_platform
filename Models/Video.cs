namespace Educational_Medical_platform.Models
{
    public class Video
    {
        // 1ry key
        public int Id { get; set; }
        public int Number { get; set; }    // no of video in this course videos 
        public string Title { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public string? Description { get; set; }
        public IFormFile video { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }

        // not valuable from saeed opinion
        //public string Size { get; set; }
        //public string Type { get; set; }
    }
}
