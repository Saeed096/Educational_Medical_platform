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
        private readonly string _imagesPath;

        ///TODO : Don't Forget to make end point for assigning question to blog 
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Blogs");
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
                Image = b.Image,
                ImageURL = b.ImageURL,
                LikesNumber = b.LikesNumber,

            }).ToList();

            if (blogs is null || !blogs.Any())
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

        [HttpGet("/category/{id:int}")]
        public ActionResult<GeneralResponse> GetByCategoryId(int id)
        {
            List<GetBlogsDTO>? blogsDTOs = _blogRepository.FindAll(includes: null, b => b.CategoryId == id).Select(b => new GetBlogsDTO()
            {
                Id = b.Id,
                Title = b.Title,

                CategoryId = b.CategoryId,
                SubCategoryId = b.SubCategoryId,

                Content = b.Content,
                Image = b.Image,
                ImageURL = b.ImageURL,
                LikesNumber = b.LikesNumber,

            }).ToList();

            if (blogsDTOs is null || !blogsDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No blog found with this Category ID : {id}"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blogsDTOs,
            };
        }

        [HttpGet("/subcategory/{id:int}")]
        public ActionResult<GeneralResponse> GetBySubCategoryId(int id)
        {
            List<GetBlogsDTO>? blogsDTOs = _blogRepository.FindAll(includes: null, b => b.SubCategoryId == id).Select(b => new GetBlogsDTO()
            {
                Id = b.Id,
                Title = b.Title,

                CategoryId = b.CategoryId,
                SubCategoryId = b.SubCategoryId,

                Content = b.Content,
                Image = b.Image,
                ImageURL = b.ImageURL,
                LikesNumber = b.LikesNumber,

            }).ToList();

            if (blogsDTOs is null || !blogsDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No blog found with this SubCategory ID : {id}"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blogsDTOs,
            };
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> Add([FromForm] AddBlogDTO createBlogDTO)
        {
            string fileName = "";

            if (createBlogDTO.Image != null)
            {
                // Validate image size (e.g., max 2MB)
                if (createBlogDTO.Image.Length > 2 * 1024 * 1024)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB."
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(createBlogDTO.Image.FileName)}_{Guid.NewGuid()}{Path.GetExtension(createBlogDTO.Image.FileName)}";
                var filePath = Path.Combine(_imagesPath, fileName);

                // Save the image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createBlogDTO.Image.CopyToAsync(stream);
                }

                createBlogDTO.Image = null; // Remove the image from DTO after saving
            }

            /// TODO : Uncomment when maher Finshes CategoryRepo & SubCategoryRepo
            #region Check if Category & SubCategory exists
            //// Check if Category exists
            //if (createBlogDTO.CategoryId != null && !_categoryRepository.Exists(createBlogDTO.CategoryId.Value))
            //{
            //    return new GeneralResponse()
            //    {
            //        IsSuccess = false,
            //        Message = $"Category with ID {createBlogDTO.CategoryId} does not exist."
            //    };
            //}

            //// Check if SubCategory exists
            //if (createBlogDTO.SubCategoryId != null && !_subCategoryRepository.Exists(createBlogDTO.SubCategoryId.Value))
            //{
            //    return new GeneralResponse()
            //    {
            //        IsSuccess = false,
            //        Message = $"SubCategory with ID {createBlogDTO.SubCategoryId} does not exist."
            //    };
            //} 
            #endregion
            /// TODO : Dont forget to check alo if the subcategoryId exists in the category

            var blog = new Blog
            {
                Title = createBlogDTO.Title,
                Content = createBlogDTO.Content,
                SubCategoryId = createBlogDTO.SubCategoryId,
                CategoryId = createBlogDTO.CategoryId,
                ImageURL = $"/Images/Blogs/{fileName}"
            };

            _blogRepository.Add(blog);
            await _blogRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blog,
                Message = "Blog added successfully."
            };
        }

        [HttpPut]
        public async Task<ActionResult<GeneralResponse>> Edit([FromForm] UpdateBlogDTO updateBlogDTO)
        {
            var blog = _blogRepository.GetById(updateBlogDTO.Id);

            string fileName = "";

            if (blog == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Blog not found."
                };
            }

            if (updateBlogDTO.Image != null)
            {
                // Validate image size (e.g., max 2MB)
                if (updateBlogDTO.Image.Length > 2 * 1024 * 1024)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB."
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(updateBlogDTO.Image.FileName)}_{Guid.NewGuid()}{Path.GetExtension(updateBlogDTO.Image.FileName)}";
                var filePath = Path.Combine(_imagesPath, fileName);

                // Save the image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateBlogDTO.Image.CopyToAsync(stream);
                }

                blog.ImageURL = $"/Images/Blogs/{fileName}";
            }

            blog.Title = updateBlogDTO.Title;
            blog.Content = updateBlogDTO.Content;
            blog.SubCategoryId = updateBlogDTO.SubCategoryId;
            blog.CategoryId = updateBlogDTO.CategoryId;
            //blog.ImageURL = fileName;

            _blogRepository.Update(blog);
            await _blogRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blog,
                Message = "Blog updated successfully."
            };
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> Delete(int id)
        {
            var blog = _blogRepository.GetById(id);

            if (blog == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "Blog not found."
                };
            }

            if (!string.IsNullOrEmpty(blog.ImageURL))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", blog.ImageURL.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _blogRepository.Delete(blog);
            await _blogRepository.SaveAsync();

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Blog deleted successfully."
            };
        }

    }
}