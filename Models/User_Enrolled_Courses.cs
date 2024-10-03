using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Models
{
    public class User_Enrolled_Courses
    {
        // comp 1ry key
        public string StudentId { get; set; }

        public int CourseId { get; set; }

        public ApplicationUser Student { get; set; }

        public Course Course { get; set; }

        //----------------------------------

        public float? Degree { get; set; }

        // to be handeled 

        public int CurrentVideoNumber { get; set; } // to handle the progress ratio for each student

        public DateTime StartDate { get; set; }

        //public int CertifiedHours { get; set; }

        //public CertificateDetails? CertificateDetails { get; set; }

        //******************************************

        //// comp 1ry key
        //public int StudentId { get; set; } 
        //public int CourseId { get; set; }

        //public Student Student { get; set; }
        //public Course Course { get; set; }

        //public float? Degree { get; set; }

        //// to be handeled 

        //public int VideoNumber { get; set; } = 0;

        //public CertificateDetails? CertificateDetails { get; set; }
    }
}