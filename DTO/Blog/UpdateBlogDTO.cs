﻿using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.Blog
{
    public class UpdateBlogDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        public string Intro { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 100)]
        public string Content { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        public string Conclusion { get; set; }

        public int? SubCategoryId { get; set; }
        public int CategoryId { get; set; }

        public IFormFile? Image { get; set; }
    }
}