namespace Educational_Medical_platform.Models
{
    public class CertificateDetails
    {
        // compos p.k
        public int StudentId { get; set; }
        public int CourseId { get; set; }


        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CertifiedHours { get; set; }
    }
}
