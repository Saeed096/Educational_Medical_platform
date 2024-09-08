using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Models
{
    public class Like
    {
        // compos 1ry key
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
