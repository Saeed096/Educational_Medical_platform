namespace Educational_Medical_platform.DTO.Blog
{
    public class GetBlogsDTO
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public int LikesNumber { get; set; } = 0;

        public string? ImageURL { get; set; }

        public IFormFile? Image { get; set; }

        public string Title { get; set; }

        public string Intro { get; set; }

        public string Content { get; set; }

        public string Conclusion { get; set; }

        public int? SubCategoryId { get; set; }
        //public string? SubCategoryName { get; set; }


        public int? CategoryId { get; set; }
        //public string? Categoryname { get; set; }

        //public List<Question>? Questions { get; set; }

        //public List<Blog_User_Likes>? Likes { get; set; }  // empty list by default
    }
}