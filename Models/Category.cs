﻿namespace Educational_Medical_platform.Models
{
    public class Category
    {
        // pk
        public int Id { get; set; }

        public List<SubCategory>? SubCategories { get; set; }
        public List<Book>? Books { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
