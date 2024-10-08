﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class Book
    {
        // p.k
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? PublisherName { get; set; }
        public string? PublisherRole { get; set; }
        public DateTime? PublishDate { get; set; }

        public string? ThumbnailURL { get; set; }
        [NotMapped]
        public IFormFile? Thumbnail { get; set; }

        public string Url { get; set; }

        // fk
        [ForeignKey("SubCategory")]

        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }


        // fk
        [ForeignKey("Category")]

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
