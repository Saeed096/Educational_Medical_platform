using Educational_Medical_platform.DTO.Blog;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
           List<GetBlogsDTO> blogs = _blogRepository.FindAll().Select(b => new GetBlogsDTO()
           {
               Id = b.Id,
               Title = b.Title,

               CategoryId = b.CategoryId,
               SubCategoryId = b.SubCategoryId,

               Content = b.Content,
               Image = b.Image ,
               ImageURL = b.ImageURL,
               LikesNumber = b.LikesNumber,

           }).ToList();

            if(blogs is null || !blogs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = blogs,
                    Message = "There Are no Blogs Available."
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blogs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Blog? blog = _blogRepository.GetById(id);

            if (blog is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No blog found with this ID : {id}"
                };
            }

            GetBlogsDTO blogDTO = new GetBlogsDTO()
            {
                Id = blog.Id,
                Title = blog.Title,

                CategoryId = blog.CategoryId,
                SubCategoryId = blog.SubCategoryId,

                Content = blog.Content,
                Image = blog.Image,
                ImageURL = blog.ImageURL,
                LikesNumber = blog.LikesNumber,
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blogDTO,
            };
        }

    }
}