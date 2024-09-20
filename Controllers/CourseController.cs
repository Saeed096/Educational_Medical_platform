using AutoMapper;
using Educational_Medical_platform.DTO.Course;
using Educational_Medical_platform.DTO.Objective;
using Educational_Medical_platform.DTO.Question;
using Educational_Medical_platform.DTO.Requirement;
using Educational_Medical_platform.DTO.Video;
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
        private readonly IRequirementRepository _requirementRepository;
        private readonly ICourseObjectiveRepository _courseObjectiveRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public CourseController(ICourseRepository CourseRepository, IRequirementRepository RequirementRepository,
            IMapper mapper, ICourseObjectiveRepository courseObjectiveRepository, IVideoRepository videoRepository,
            IQuestionRepository questionRepository)
        {
            _courseRepository = CourseRepository;
            _requirementRepository = RequirementRepository;
            _mapper = mapper;
            _courseObjectiveRepository = courseObjectiveRepository;
            _videoRepository = videoRepository;
            _questionRepository = questionRepository;
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

               IEnumerable<Requirement> requirements = _requirementRepository.FindAll(criteria : r => r.CourseId == id);
                if(requirements.Any())
                {
                    List<GetRequirementDTO> requirementDTOs = new List<GetRequirementDTO>();
                        _mapper.Map(requirements, requirementDTOs);

                    courseDTO.Requirements = requirementDTOs;
                }
                IEnumerable<Objective> objectives = _courseObjectiveRepository.FindAll(criteria: o => o.CourseId == id);
                if (objectives.Any())
                {
                    List<GetObjectiveDTO> objectiveDTOs = new List<GetObjectiveDTO>();
                    _mapper.Map(objectives, objectiveDTOs);

                    courseDTO.Objectives = objectiveDTOs;
                }


                IEnumerable<Video> videos = _videoRepository.FindAll(criteria: v => v.CourseId == id);
                if (videos.Any())
                {
                    List<GetVideoDTO> videoDTOs = new List<GetVideoDTO>();
                    _mapper.Map(videos, videoDTOs);

                    courseDTO.Videos = videoDTOs;
                }

                IEnumerable<Question> questions = _questionRepository.FindAll(criteria: q => q.CourseId == id);
                if (questions.Any())
                {
                    List<GetQuestionDTO> questionDTOs = new List<GetQuestionDTO>();
                    _mapper.Map(questions, questionDTOs);

                    courseDTO.Questions = questionDTOs;
                }


                return new GeneralResponse
                {
                    IsSuccess = true,
                    Data = courseDTO,
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


        [HttpPost]
        public ActionResult<GeneralResponse> Add (AddCourseDTO CourseDTO)
        {
            if(!ModelState.IsValid)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Invalid data"
                };
            }


        }
    }
}
