using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseObjectiveRepository _courseObjectiveRepository;
        private readonly ICourseRequirementsRepository _courseRequirementsRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly string _imagesPath;

        public CourseController(ICourseRepository courseRepository,
            ICourseObjectiveRepository courseObjectiveRepository,
            ICourseRequirementsRepository courseRequirementsRepository,
            UserManager<ApplicationUser> userManager)
        {
            _courseRepository = courseRepository;
            _courseObjectiveRepository = courseObjectiveRepository;
            _courseRequirementsRepository = courseRequirementsRepository;
            _userManager = userManager;
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Courses");

        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Course> courses = _courseRepository.FindAll(includes: new[] { "Requirements", "Objectives" }).ToList();

            if (courses == null || !courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "There are no courses available"
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Preview = course.Preview,
                    Title = course.Title,
                    DurationInhours = course.DurationInhours,

                    InstructorId = course.InstructorId,
                    SubCategoryId = course.SubCategoryId,

                    ThumbnailURL = course.ThumbnailURL,

                    Requirements = course.Requirements != null && course.Requirements.Any()
                        ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseRequirmentsDTO>(), // Provide an empty list if there are no requirements

                    Objectives = course.Objectives != null && course.Objectives.Any()
                        ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseObjectiveDTO>(), // Provide an empty list if there are no Objectives
                };

                courseDTOs.Add(courseDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Courses retrieved with Requirments and objectives successfully.",
                Data = courseDTOs
            };
        }


        [HttpGet("{courseId:int}")]
        public ActionResult<GeneralResponse> GetByCourseId(int courseId)
        {
            Course? course = _courseRepository.Find(criteria: c => c.Id == courseId, includes: new[] { "Requirements", "Objectives" });

            if (course == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no course with this ID : {courseId} "
                };
            }

            GetCourseDTO courseDTO = new GetCourseDTO()
            {
                Id = course.Id,

                Preview = course.Preview,
                Title = course.Title,
                DurationInhours = course.DurationInhours,

                InstructorId = course.InstructorId,
                SubCategoryId = course.SubCategoryId,

                ThumbnailURL = course.ThumbnailURL ?? "NA",

                Requirements = course.Requirements != null && course.Requirements.Any()
                    ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                    {
                        Id = req.Id,
                        CourseId = req.CourseId,
                        Description = req.Description,
                    }).ToList()
                    : new List<GetCourseRequirmentsDTO>(), // Provide an empty list if there are no requirements

                Objectives = course.Objectives != null && course.Objectives.Any()
                    ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                    {
                        Id = req.Id,
                        CourseId = req.CourseId,
                        Description = req.Description,
                    }).ToList()
                    : new List<GetCourseObjectiveDTO>(), // Provide an empty list if there are no Objectives
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Course retrieved with Requirments and objectives successfully.",
                Data = courseDTO
            };
        }

        [HttpGet("Instructor/{instructorId}")]
        public async Task<ActionResult<GeneralResponse>> GetByInstructorId(string instructorId)
        {
            var instructor = await _userManager.FindByIdAsync(instructorId);

            if (instructor == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no user Found with this ID : {instructorId}",
                    Status = 404,
                };
            }

            List<Course> courses = _courseRepository.FindAll(criteria: c => c.InstructorId == instructorId, includes: new[] { "Requirements", "Objectives" }).ToList();

            if (courses == null || !courses.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There are no courses available for this User ID : {instructorId}"
                };
            }

            var courseDTOs = new List<GetCourseDTO>();

            foreach (var course in courses)
            {
                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    Id = course.Id,

                    Title = course.Title,
                    DurationInhours = course.DurationInhours,
                    Preview = course.Preview,

                    InstructorId = course.InstructorId,
                    SubCategoryId = course.SubCategoryId,

                    ThumbnailURL = course.ThumbnailURL,

                    Requirements = course.Requirements != null && course.Requirements.Any()
                        ? course.Requirements.Select(req => new GetCourseRequirmentsDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseRequirmentsDTO>(), // Provide an empty list if there are no requirements

                    Objectives = course.Objectives != null && course.Objectives.Any()
                        ? course.Objectives.Select(req => new GetCourseObjectiveDTO()
                        {
                            Id = req.Id,
                            CourseId = req.CourseId,
                            Description = req.Description,
                        }).ToList()
                        : new List<GetCourseObjectiveDTO>(), // Provide an empty list if there are no Objectives
                };

                courseDTOs.Add(courseDTO);
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Courses retrieved with Requirments and objectives successfully.",
                Data = courseDTOs
            };
        }

        [HttpPost]
        public async Task<ActionResult<GeneralResponse>> AddCourse([FromForm]AddCourseDTO courseDTO)
        {
            // Check if the instructor exists
            var instructor = await _userManager.FindByIdAsync(courseDTO.InstructorID);
            if (instructor == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = $"There is no user found with this ID: {courseDTO.InstructorID}",
                    Status = 404,
                };
            }

            string fileName = "";

            if (courseDTO.Thumbnail != null)
            {
                // Validate image size (e.g., max 2MB)
                if (courseDTO.Thumbnail.Length > 2 * 1024 * 1024)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB."
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(courseDTO.Thumbnail.FileName)}_{Guid.NewGuid()}{Path.GetExtension(courseDTO.Thumbnail.FileName)}";
                var filePath = Path.Combine(_imagesPath, fileName);

                // Save the image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await courseDTO.Thumbnail.CopyToAsync(stream);
                }

                courseDTO.Thumbnail = null; // Remove the image from DTO after saving
            }


            // Map the DTO to the Course entity
            var newCourse = new Course
            {
                Title = courseDTO.Title,
                DurationInhours = courseDTO.DurationInhours,
                Preview = courseDTO.Preview,
                InstructorId = courseDTO.InstructorID,
                SubCategoryId = courseDTO.SubCategoryId,
                ThumbnailURL = $"/Images/Courses/{fileName}",

                //ThumbnailURL = courseDTO.ThumbnailURL,
                Requirements = courseDTO.Requirements?.Select(req => new Requirement
                {
                    Description = req.Description
                }).ToList(),
                Objectives = courseDTO.Objectives?.Select(obj => new Objective
                {
                    Description = obj.Description
                }).ToList()
            };

            // Add the course to the repository
            _courseRepository.Add(newCourse);
            await _courseRepository.SaveAsync();

            GetCourseDTO getCourseDTO = new GetCourseDTO
            {
                Id = newCourse.Id,
                Title = courseDTO.Title,
                DurationInhours = courseDTO.DurationInhours,
                Preview = courseDTO.Preview,
                InstructorId = courseDTO.InstructorID,
                SubCategoryId = courseDTO.SubCategoryId,
                ThumbnailURL = $"/Images/Courses/{fileName}",

                Requirements = courseDTO.Requirements?.Select(req => new GetCourseRequirmentsDTO
                {
                    Description = req.Description
                }).ToList(),

                Objectives = courseDTO.Objectives?.Select(obj => new GetCourseObjectiveDTO
                {
                    Description = obj.Description
                }).ToList(),
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Message = "Course created successfully.",
                Data = getCourseDTO
            };
        }

    }
}