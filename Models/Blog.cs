namespace Educational_Medical_platform.Models
{
    public class Blog
    {
        // p.k
        public int Id { get; set; }

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

    }
}
