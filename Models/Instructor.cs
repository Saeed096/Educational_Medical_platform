using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

    }
}
