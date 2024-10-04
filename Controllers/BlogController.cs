using Educational_Medical_platform.DTO.Blog;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IBlog_User_LikesRepository _user_LikesRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly string _imagesPath;

        ///TODO : Don't Forget to make end point for assigning question to blog 
        public BlogController(IBlogRepository blogRepository,
            IBlog_User_LikesRepository user_LikesRepository,
            UserManager<ApplicationUser> userManager,
            ICategoryRepository categoryRepository,
            ISubCategoryRepository subCategoryRepository,
            IQuestionRepository questionRepository ,
            IAnswerRepository answerRepository)
        {
            _blogRepository = blogRepository;
            _user_LikesRepository = user_LikesRepository;
            _userManager = userManager;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
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
                AuthorId = b.AuthorId,

                Intro = b.Intro,
                Content = b.Content,
                Conclusion = b.Conclusion,

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
                AuthorId = blog.AuthorId,


                Intro = blog.Intro,
                Content = blog.Content,
                Conclusion = blog.Conclusion,

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

        [HttpGet("category/{id:int}")]
        public ActionResult<GeneralResponse> GetByCategoryId(int id)
        {
            List<GetBlogsDTO>? blogsDTOs = _blogRepository.FindAll(includes: null, b => b.CategoryId == id).Select(b => new GetBlogsDTO()
            {
                Id = b.Id,
                Title = b.Title,

                CategoryId = b.CategoryId,
                SubCategoryId = b.SubCategoryId,
                AuthorId = b.AuthorId,


                Intro = b.Intro,
                Content = b.Content,
                Conclusion = b.Conclusion,

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

        [HttpGet("Author/{id}")]
        public ActionResult<GeneralResponse> GetByAuthorId(string id)
        {
            List<GetBlogsDTO>? blogsDTOs = _blogRepository.FindAll(includes: null, b => b.AuthorId == id).Select(b => new GetBlogsDTO()
            {
                Id = b.Id,
                Title = b.Title,

                CategoryId = b.CategoryId,
                SubCategoryId = b.SubCategoryId,
                AuthorId = b.AuthorId,


                Intro = b.Intro,
                Content = b.Content,
                Conclusion = b.Conclusion,

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
                    Message = $"No blog found for this AuthorID : {id}"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blogsDTOs,
            };
        }

        [HttpGet("subcategory/{id:int}")]
        public ActionResult<GeneralResponse> GetBySubCategoryId(int id)
        {
            List<GetBlogsDTO>? blogsDTOs = _blogRepository.FindAll(includes: null, b => b.SubCategoryId == id).Select(b => new GetBlogsDTO()
            {
                Id = b.Id,
                Title = b.Title,

                CategoryId = b.CategoryId,
                SubCategoryId = b.SubCategoryId,
                AuthorId = b.AuthorId,


                Intro = b.Intro,
                Content = b.Content,
                Conclusion = b.Conclusion,

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
            var user = await _userManager.FindByIdAsync(createBlogDTO.AuthorId);

            if (user is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Status = 404,
                    Message = $"No User Found with this ID : {createBlogDTO.AuthorId}"
                };
            }

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

            #region Check if Category & SubCategory exists

            // Check if Category exists
            if (createBlogDTO.CategoryId != 0 && !_categoryRepository.Exists(createBlogDTO.CategoryId))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"Category with ID {createBlogDTO.CategoryId} does not exist."
                };
            }

            if (createBlogDTO.SubCategoryId != null)
            {
                // Check if SubCategory exists
                if (createBlogDTO.SubCategoryId != null && !_subCategoryRepository.Exists(createBlogDTO.SubCategoryId.Value))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = $"SubCategory with ID {createBlogDTO.SubCategoryId} does not exist."
                    };
                }

                // Check if SubCategory is related to the category
                var subcategory = _subCategoryRepository.GetById((int)createBlogDTO.SubCategoryId);

                if (subcategory.CategoryId != createBlogDTO.CategoryId)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = $"SubCategory with ID {createBlogDTO.SubCategoryId} does not exist in the Categoru with ID :{createBlogDTO.CategoryId}"
                    };
                }
            }

            #endregion

            var blog = new Blog
            {
                Title = createBlogDTO.Title,
                AuthorId = createBlogDTO.AuthorId,

                Intro = createBlogDTO.Intro,
                Content = createBlogDTO.Content,
                Conclusion = createBlogDTO.Conclusion,

                SubCategoryId = createBlogDTO.SubCategoryId ?? null,
                CategoryId = createBlogDTO.CategoryId,
                ImageURL = $"/Images/Blogs/{fileName}"
            };

            _blogRepository.Add(blog);
            await _blogRepository.SaveAsync();

            GetBlogsDTO blogDTO = new GetBlogsDTO()
            {
                Title = createBlogDTO.Title,
                AuthorId = createBlogDTO.AuthorId,

                Intro = createBlogDTO.Intro,
                Content = createBlogDTO.Content,
                Conclusion = createBlogDTO.Conclusion,

                SubCategoryId = createBlogDTO.SubCategoryId ?? null,
                CategoryId = createBlogDTO.CategoryId,
                ImageURL = $"/Images/Blogs/{fileName}"
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blogDTO,
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

            #region Check if Category & SubCategory exists

            // Check if Category exists
            if (updateBlogDTO.CategoryId != 0 && !_categoryRepository.Exists(updateBlogDTO.CategoryId))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"Category with ID {updateBlogDTO.CategoryId} does not exist."
                };
            }

            if (updateBlogDTO.SubCategoryId != null)
            {
                // Check if SubCategory exists
                if (updateBlogDTO.SubCategoryId != null && !_subCategoryRepository.Exists(updateBlogDTO.SubCategoryId.Value))
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = $"SubCategory with ID {updateBlogDTO.SubCategoryId} does not exist."
                    };
                }

                // Check if SubCategory is related to the category
                var subcategory = _subCategoryRepository.GetById((int)updateBlogDTO.SubCategoryId);

                if (subcategory.CategoryId != updateBlogDTO.CategoryId)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = $"SubCategory with ID {updateBlogDTO.SubCategoryId} does not exist in the Categoru with ID :{updateBlogDTO.CategoryId}"
                    };
                }
            }

            #endregion


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

            blog.Intro = updateBlogDTO.Intro;
            blog.Content = updateBlogDTO.Content;
            blog.Conclusion = updateBlogDTO.Conclusion;

            blog.SubCategoryId = updateBlogDTO.SubCategoryId ?? null;
            blog.CategoryId = (int)updateBlogDTO.CategoryId;
            //blog.ImageURL = fileName;

            _blogRepository.Update(blog);
            await _blogRepository.SaveAsync();

            GetBlogsDTO blogDTO = new GetBlogsDTO()
            {
                Title = updateBlogDTO.Title,

                Intro = updateBlogDTO.Intro,
                Content = updateBlogDTO.Content,
                Conclusion = updateBlogDTO.Conclusion,

                SubCategoryId = updateBlogDTO.SubCategoryId ?? null,
                CategoryId = updateBlogDTO.CategoryId,
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = blogDTO,
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

            // Delete related questions
            var questions =  _questionRepository.FindAll(criteria: q => q.BlogId == id, includes: new[] { "Answers" }); // Get related questions

            if (questions != null && questions.Any())
            {
                foreach (var question in questions)
                {
                    // Delete all related answers for each question
                    _answerRepository.DeleteRange(question.Answers);
                }

                // Save the answer deletions before deleting questions
                await _answerRepository.SaveAsync();

                // Now delete all the questions
                _questionRepository.DeleteRange(questions);
                await _questionRepository.SaveAsync();
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
                Message = "Blog and all of it's questions deleted successfully."
            };
        }

        [HttpGet("like/{userId}/{blogId:int}")]
        public async Task<ActionResult<GeneralResponse>> Like(string userId, int blogId)
        {
            // Check if the user exists
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"User with ID : {userId} does not exist."
                };
            }

            // Check if the blog exists
            var blog = await _blogRepository.GetByIdAsync(blogId); // Assuming you have a method to get blog by ID
            if (blog == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"Blog with ID : {blogId} does not exist."
                };
            }

            // Check if the user has already liked the blog
            var existingLike = _user_LikesRepository.FindAll(criteria: l => l.UserId == userId && l.BlogId == blogId).FirstOrDefault();
            if (existingLike != null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"User with ID : {userId} has already liked the Blog with ID : {blogId}."
                };
            }

            // Create and add the like
            Blog_User_Likes like = new Blog_User_Likes()
            {
                UserId = userId,
                BlogId = blogId
            };

            _user_LikesRepository.Add(like);
            await _user_LikesRepository.SaveAsync();

            blog.LikesNumber++;
            await _blogRepository.SaveAsync();

            return new GeneralResponse
            {
                IsSuccess = true,
                Message = $"User with ID : {userId} liked the Blog with ID : {blogId} successfully."
            };
        }

    }
}