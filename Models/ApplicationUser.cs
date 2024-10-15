using Educational_Medical_platform.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shoghlana.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string LastName { get; set; }

        public string? ImageUrl { get; set; }

        //-------------------------------------------
         // Courses this user has created as an instructor
        public List<Course>? CoursesCreated { get; set; }

        // Navigation property for enrolled courses
        public List<User_Enrolled_Courses>? EnrolledCourses { get; set; }

        //--------------------------------------------

        public List<Blog>? Blogs { get; set; }

        public List<Book>? Books { get; set; }

        public bool IsSubscribedToPlatform { get; set; } = false;
    }
}