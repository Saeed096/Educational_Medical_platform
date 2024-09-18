using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.DTO.BookDTO
{
    public class BookDTO
    {

        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? ThumbnailURL { get; set; }
        [NotMapped]
        public IFormFile? Thumbnail { get; set; }

        public string? Url { get; set; }

        public int? SubCategoryId { get; set; }

        public int? CategoryId { get; set; }

    }
}
