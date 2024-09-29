namespace Educational_Medical_platform.DTO.Course
{
    public class GetVideoDTO
    {
        public int Id { get; set; }

        public int Number { get; set; }    

        public string Title { get; set; }

        public string? Description { get; set; }

        public string? videoURL { get; set; }

        //[NotMapped]
        //public IFormFile? video { get; set; }

        public int CourseId { get; set; }
    }
}