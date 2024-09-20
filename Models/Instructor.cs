using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string LastName { get; set; }

        public ApplicationUser User { get; set; }


        // why validation here >> should be in dtos , register logic for ins validate on having 1 course at least????
        public List<Course> Courses { get; set; }
    }
}