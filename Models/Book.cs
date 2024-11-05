using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public string? PublisherName { get; set; }

        public string? PublisherRole { get; set; }

        public DateTime? PublishDate { get; set; } 

        public string? ThumbnailURL { get; set; }

        public string Url { get; set; }

        //----------------------------------------

        [ForeignKey(nameof(SubCategory))]
        public int? SubCategoryId { get; set; }

        public SubCategory? SubCategory { get; set; }

        //----------------------------------------

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        //----------------------------------------

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}