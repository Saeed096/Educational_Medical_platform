namespace Educational_Medical_platform.Models
{
    public class Category
    {
        // pk
        public int Id { get; set; }

        public List<SubCategory>? SubCategories { get; set; }
    }
}
