using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Models
{
    public class Blog_User_Likes
    {
        // compos 1ry key
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
