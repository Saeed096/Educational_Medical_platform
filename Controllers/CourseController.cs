using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository CourseRepository)
        {
            _courseRepository = CourseRepository;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<Course> Courses = new List<Course>();
            Courses = (List<Course>)_courseRepository.FindAll();

            if (Courses is not null && Courses.Any())
            {
                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = Courses,
                    Message = "All courses retrieved successfully"
                };
            }

            return new GeneralResponse
            {
                IsSuccess = false,
                Data = null,
                Message = "No courses found"
            };
        }


        [HttpGet("{id : int}")]
        public ActionResult<GeneralResponse> GetById(int id) 
        { 
          Course? Course = _courseRepository.GetById(id);
        
            if(Course != null)
            {
                GetCourseDTO courseDTO = new GetCourseDTO();
                courseDTO.Id = id;
                courseDTO.DurationInhours = Course.DurationInhours;
                courseDTO.SubCategoryId = Course.SubCategoryId;
                courseDTO.Preview  = Course.Preview;
                courseDTO.Title = Course.Title;
                courseDTO.ThumbnailURL = Course.ThumbnailURL;
                // loop on obj , quest .... then map on dto 

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = Course,
                    Message = "course retrieved successfully"
                };
            }
            return new GeneralResponse
            {
                IsSuccess = false,
                Data = null,
                Message = "No course found for this id"
            };

        }
    }
}
