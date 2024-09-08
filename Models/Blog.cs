namespace Educational_Medical_platform.Models
{
    public class Blog
    {
        // p.k
        public int Id { get; set; }
        public int LikesNumber { get; set; } = 0;

        public IFormFile? Image { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; } 
        // fk
        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }


        // fk
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Question>? Questions { get; set; }
        public List<Like> Likes { get; set; } = new List<Like>();  // empty list by default

    }
}
