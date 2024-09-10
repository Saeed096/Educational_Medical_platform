namespace Educational_Medical_platform.Models
{
    public class StudentCourses
    {
        // comp 1ry key
        public int StudentId { get; set; } 
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

        public float? Degree { get; set; }

        // to be handeled 

        public int VideoNumber { get; set; } = 0;
        public CertificateDetails? CertificateDetails { get; set; }
    }
}
