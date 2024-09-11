using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Must be within (3-50) chars")]
        public string LastName { get; set; }

        public ApplicationUser User { get; set; }

        public bool IsSubscribed { get; set; }
    }
}