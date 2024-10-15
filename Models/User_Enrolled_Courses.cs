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

        //******************************************

        //// TODO : Make Logic To handle The current Video each user Stopped at (progress)

        //public int VideoNumber { get; set; } = 0;

        //public CertificateDetails? CertificateDetails { get; set; }
    }
}