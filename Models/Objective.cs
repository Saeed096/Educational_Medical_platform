namespace Educational_Medical_platform.Models
{
    public class Objective
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
