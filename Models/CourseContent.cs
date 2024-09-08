namespace Educational_Medical_platform.Models
{
    // course content in dbcontext or not???????????
    // why course content , can link course with videos direct????????
    public class CourseContent
    {
        // 1ry key
        public int Id { get; set; }
        public Course Course { get; set; }

        // foreign key
        public int CourseId { get; set; }

        public List<Video> Videos { get; set; }
    }
}
