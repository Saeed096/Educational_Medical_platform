using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Models
{
    public class Student
    {
        public ApplicationUser User { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
