using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        public int LikesNumber { get; set; } = 0;

        public string? ImageURL { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Title Must be within (3-50) chars")]
        public string Title { get; set; }

        [StringLength(maximumLength: 5000, MinimumLength = 100, ErrorMessage = "Content Must be within (100-5000) chars")]
        public string Content { get; set; }

        [ForeignKey("SubCategory")]
        public int? SubCategoryId { get; set; }

        public SubCategory? SubCategory { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public List<Question>? Questions { get; set; }

        public List<Blog_User_Likes>? Likes { get; set; }  // empty list by default

    }
}