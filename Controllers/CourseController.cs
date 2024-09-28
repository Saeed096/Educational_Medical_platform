using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.Course.Objectives;
using Educational_Medical_platform.DTO.Course.Requirments;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseObjectiveRepository _courseObjectiveRepository;
        private readonly ICourseRequirementsRepository _courseRequirementsRepository;

        public CourseController(ICourseRepository courseRepository,
            ICourseObjectiveRepository courseObjectiveRepository,
            ICourseRequirementsRepository courseRequirementsRepository)
        {
            _courseRepository = courseRepository;
            _courseObjectiveRepository = courseObjectiveRepository;
            _courseRequirementsRepository = courseRequirementsRepository;
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
    }
}