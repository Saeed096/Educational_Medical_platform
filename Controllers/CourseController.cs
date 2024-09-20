using AutoMapper;
using Educational_Medical_platform.DTO.Answer;
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
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IInstructorRepository _instructorRepository; 
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        private readonly string _imagesPath;
        private readonly string _videosPath;
        public CourseController(ICourseRepository CourseRepository, IRequirementRepository RequirementRepository,
            IMapper mapper, ICourseObjectiveRepository courseObjectiveRepository, IVideoRepository videoRepository,
            IQuestionRepository questionRepository, ISubCategoryRepository subCategoryRepository,
            IInstructorRepository instructorRepository, IAnswerRepository answerRepository)
        {
            _courseRepository = CourseRepository;
            _requirementRepository = RequirementRepository;
            _mapper = mapper;
            _courseObjectiveRepository = courseObjectiveRepository;
            _videoRepository = videoRepository;
            _questionRepository = questionRepository;
            _subCategoryRepository = subCategoryRepository;
            _instructorRepository = instructorRepository;
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Courses");
            _videosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Videos", "Courses");
            _answerRepository = answerRepository;
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


        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Course? Course = _courseRepository.GetById(id);

            if (Course != null)
            {
                GetCourseDTO courseDTO = new GetCourseDTO();
                courseDTO.Id = id;
                courseDTO.DurationInhours = Course.DurationInhours;
                courseDTO.SubCategoryId = Course.SubCategoryId;
                courseDTO.Preview = Course.Preview;
                courseDTO.Title = Course.Title;
                courseDTO.ThumbnailURL = Course.ThumbnailURL;

                IEnumerable<Requirement> requirements = _requirementRepository.FindAll(criteria: r => r.CourseId == id);
                if (requirements.Any())
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
        public async Task <ActionResult<GeneralResponse>> AddAsync ([FromForm] AddCourseDTO CourseDTO)
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

            SubCategory? SubCategory = _subCategoryRepository.GetById(CourseDTO.SubCategoryId);
            if(SubCategory is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "no subcategory found for this id"
                };
            }

            Instructor? Instructor = _instructorRepository.GetById(CourseDTO.InstructorId);
            if (Instructor is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "no instructor found for this id"
                };
            }

            Course course = new Course();

            course.SubCategoryId = CourseDTO.SubCategoryId;
            course.Preview = CourseDTO.Preview;
            course.Title = CourseDTO.Title;
            course.InstructorId = CourseDTO.InstructorId;
          
            //course.DurationInhours =          // will be calc based on videos length



            string fileName = "";
            var filePath = "";

            if (CourseDTO.Thumbnail != null)
            {
                // Validate image size (e.g., max 2MB)
                if (CourseDTO.Thumbnail.Length > 2 * 1024 * 1024)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Message = "Image size exceeds the maximum allowed size of 2MB."
                    };
                }

                // Generate a unique filename
                fileName = $"{Path.GetFileNameWithoutExtension(CourseDTO.Thumbnail.FileName)}_{Guid.NewGuid()}{Path.GetExtension(CourseDTO.Thumbnail.FileName)}";
                filePath = Path.Combine(_imagesPath, fileName);

                // Save the image
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await CourseDTO.Thumbnail.CopyToAsync(stream);
                }

                course.ThumbnailURL = filePath;

            }            

                // add lists 


                if (CourseDTO.Requirements is not null && CourseDTO.Requirements.Any())
                {
                    foreach(AddRequirementDTO requirementDTO in CourseDTO.Requirements)
                    {
                        Requirement requirement = new Requirement();
                        _mapper.Map(requirementDTO, requirement);
                        requirement.CourseId = course.Id;
                        _requirementRepository.Add(requirement);
                        _requirementRepository.save();
                    }
                }


                if (CourseDTO.Objectives is not null && CourseDTO.Objectives.Any())
                {
                    foreach (AddObjectiveDTO objectiveDTO in CourseDTO.Objectives)
                    {
                        Objective objective = new Objective();
                        _mapper.Map(objectiveDTO, objective);
                        objective.CourseId = course.Id;
                        _courseObjectiveRepository.Add(objective);
                        _courseObjectiveRepository.save();
                    }
                }


                if (CourseDTO.Videos is not null && CourseDTO.Videos.Any())
                {
                    foreach (AddVideoDTO videoDTO in CourseDTO.Videos)
                    {
                        Video video = new Video();

                        if(videoDTO.Thumbnail is not null)
                        {
                            // Generate a unique filename
                            fileName = $"{Path.GetFileNameWithoutExtension(videoDTO.Thumbnail.FileName)}_{Guid.NewGuid()}{Path.GetExtension(videoDTO.Thumbnail.FileName)}";
                            filePath = Path.Combine(_imagesPath, fileName);

                            // Save the image
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await videoDTO.Thumbnail.CopyToAsync(stream);
                            }
                            _mapper.Map(videoDTO, video);
                            video.ThumbnailURL = filePath;
                        }
                        else
                        {
                            _mapper.Map(videoDTO, video);
                        }

                        if(videoDTO.video is not null)
                        {
                            // Generate a unique filename
                            fileName = $"{Path.GetFileNameWithoutExtension(videoDTO.video.FileName)}_{Guid.NewGuid()}{Path.GetExtension(videoDTO.video.FileName)}";
                            filePath = Path.Combine(_videosPath, fileName);

                            // Save the image
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await videoDTO.video.CopyToAsync(stream);
                            }
                            video.videoURL = filePath;
                            video.CourseId = course.Id;
                            _videoRepository.Add(video);
                            _videoRepository.save();
                        }
                        else
                        {
                            return new GeneralResponse()
                            {
                                IsSuccess = false,
                                Data = null,
                                Message = "Video file is missed"
                            };
                        }
                    }
                }
                else
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Cannot create course with empty videos list"
                    };
                }

                if (CourseDTO.Questions is not null && CourseDTO.Questions.Any())
                {
                    foreach (AddQuestionDTO questionDTO in CourseDTO.Questions)
                    {
                        Question question = new Question();
                        _mapper.Map(questionDTO, question);
                        question.CourseId = course.Id;
                        _questionRepository.Add(question);
                        _questionRepository.save();

                        if(questionDTO.Answers is not null && questionDTO.Answers.Any())
                        {
                            foreach(AddAnswerDTO answerDTO in questionDTO.Answers)
                            {
                                Answer answer = new Answer();
                                _mapper.Map(answerDTO, answer);
                                answer.QuestionId = question.Id;
                                _answerRepository.Add(answer);
                                _answerRepository.save();
                            }
                           
                        }
                        else
                        {
                            return new GeneralResponse()
                            {
                                IsSuccess = false,
                                Data = null,
                                Message = "cannot add question without answers"
                            };
                        }
                    }
                }

                try
            {
                _courseRepository.Add(course);
                _courseRepository.save();
            }
            catch (Exception ex)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
            }


            return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "Course added successfully :)"
                };
            }

        }
    }
