using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Blog
    {
        // p.k
        [Key]
        public int Id { get; set; }
        public int LikesNumber { get; set; } = 0;

        public string? ImageURL { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        // fk
        [ForeignKey("SubCategory")]

        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }


        // fk
        [ForeignKey("Category")]

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Question>? Questions { get; set; }
        public List<Blog_User_Likes>? Likes { get; set; }  // empty list by default

    }
}
