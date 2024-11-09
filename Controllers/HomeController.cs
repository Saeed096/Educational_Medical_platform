using Educational_Medical_platform.DTO.Blog;
using Educational_Medical_platform.DTO.BookDTO;
using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using static System.Reflection.Metadata.BlobBuilder;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ICourseRepository courseRepository,
                              IBlogRepository blogRepository,
                              IBookRepository bookRepository,
                              ICategoryRepository categoryRepository)
        {
            _courseRepository = courseRepository;
            _blogRepository = blogRepository;
            _bookRepository = bookRepository;
            this._categoryRepository = categoryRepository;
        }

        //******************************************************************

        [HttpGet("GetHomeInfo")]
        public async Task<ActionResult<GeneralResponse>> GetHomeInfo()
        {
            var recentCourses = await _courseRepository
                                       .GetRecentSixRecordsAsync(orderByProperty: c => c.Id,
                                       includes: ["Requirements", "Objectives", "SubCategory", "Instructor"]);

            var recentCoursesDTOs = new List<GetCourseDTO>();

            foreach (var course in recentCourses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Preview = course.Preview,
                    Title = course.Title,
                    DurationInhours = course.DurationInhours,
                    Price = course.Price,

                    Type = course.Type,
                    TypeName = course.Type.GetDisplayName(),

                    Status = course.Status,
                    StatusName = course.Status.GetDisplayName(),

                    RejectionReason = course.RejectedReason,

                    InstructorId = course.InstructorId,
                    InstructorFullName = $"{course.Instructor.FirstName} {course.Instructor.LastName}",

                    SubCategoryId = course.SubCategoryId,
                    SubCategoryName = course.SubCategory.Name,

                    CategoryId = course.SubCategory.CategoryId,
                    CategoryName = _categoryRepository.GetById(course.SubCategory.CategoryId).Name ?? "NA",

                    ThumbnailURL = course.ThumbnailURL,

                    Requirements = course.Requirements != null && course.Requirements.Any()
                        ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseRequirmentsDTO>(),

                    Objectives = course.Objectives != null && course.Objectives.Any()
                        ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseObjectiveDTO>(),
                };

                recentCoursesDTOs.Add(courseDTO);
            }


            var recentblogs = await _blogRepository.GetRecentSixRecordsAsync(b => b.Id);
            List<GetBlogsDTO> recentblogsDTOs = recentblogs.Select(b => new GetBlogsDTO()
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

            var recentBooks = await _bookRepository.GetRecentSixRecordsAsync(b => b.Id);

            List<BookDTO> recentBooksDTOs = recentBooks.Select(book => new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                ThumbnailURL = book.ThumbnailURL,
                Url = book.Url,
                SubCategoryId = book.SubCategoryId,
                CategoryId = book.CategoryId,
                CreatedDate = book.PublishDate,
                PublisherName = book.PublisherName,
                PublisherRole = book.PublisherRole,

            }).ToList();

            return new GeneralResponse
            {
                IsSuccess = true,
                Data = new
                {
                    recentCoursesDTOs,
                    recentblogsDTOs,
                    recentBooksDTOs
                },
                Message = "All Recent Data Retrieved successfully"
            };
        }
    }
}