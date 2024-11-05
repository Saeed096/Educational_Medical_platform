using Educational_Medical_platform.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.BookDTO
{
    public class AddBookDTO
    {
        [Required(ErrorMessage = "Title Is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Thumbnail Is Required")]
        public IFormFile Thumbnail { get; set; }

        [Required(ErrorMessage = "Url Is Required")]
        public string Url { get; set; }

        [Required(ErrorMessage = "UserID Is Required")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "PublisherName Is Required")]
        public string PublisherName { get; set; }

        [ValidDate(ErrorMessage = "CreatedDate must be a valid date in the past.")]
        public DateTime? CreatedDate { get; set; }

        public int? SubCategoryId { get; set; }
        public int? CategoryId { get; set; }
    }
  
}