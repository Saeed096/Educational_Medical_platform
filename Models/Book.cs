namespace Educational_Medical_platform.Models
{
    public class Book
    {
        // p.k
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public string Url { get; set; }

        // fk
        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }


        // fk
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
