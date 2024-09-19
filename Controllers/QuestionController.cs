using Educational_Medical_platform.DTO.Answer;
using Educational_Medical_platform.DTO.Question;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IStandardTestRepository _standardTestRepository;
        private readonly ICourseRepository _courseRepository;

        public QuestionController(IQuestionRepository questionRepository,
            ISubCategoryRepository subCategoryRepository,
            IBlogRepository blogRepository,
            IStandardTestRepository standardTestRepository ,
            ICourseRepository courseRepository)
        {
            _questionRepository = questionRepository;
            _subCategoryRepository = subCategoryRepository;
            _blogRepository = blogRepository;
            _standardTestRepository = standardTestRepository;
            _courseRepository = courseRepository;
        }

        //********************************************************************

        [HttpGet]
        public ActionResult<GeneralResponse> GetAll()
        {
            List<GetQuestionDTO> questionDTOs = _questionRepository.FindAll(includes: ["Answers"]).Select(question => new GetQuestionDTO()
            {
                Id = question.Id,
                BlogId = question.BlogId,
                CourseId = question.CourseId,
                SubCategoryId = question.SubCategoryId,
                TestId = question.TestId,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    IsCorrect = answer.IsCorrect,
                }).ToList(),
            }).ToList();

            if (questionDTOs is null || !questionDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Data = questionDTOs,
                    Message = "There Are no Questions Available."
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = questionDTOs,
            };
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetById(int id)
        {
            Question? question = _questionRepository.Find(criteria: q => q.Id == id, includes: ["Answers"]);

            if (question is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No question found with this ID : {id}"
                };
            }

            GetQuestionDTO questionDTO = new GetQuestionDTO()
            {
                Id = question.Id,
                BlogId = question.BlogId,
                CourseId = question.CourseId,
                SubCategoryId = question.SubCategoryId,
                TestId = question.TestId,
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    IsCorrect = answer.IsCorrect,
                }).ToList(),
            };

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = questionDTO,
            };
        }

        [HttpGet("subcategory/{id:int}")]
        public ActionResult<GeneralResponse> GetBySubCategoryId(int id)
        {
            if (!_subCategoryRepository.Exists(id))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No subcategory found with this ID : {id}"
                };
            }

            List<GetQuestionDTO> questionDTOs = _questionRepository.FindAll(criteria: q => q.SubCategoryId == id, includes: ["Answers"]).Select(question => new GetQuestionDTO()
            {
                Id = question.Id,
                BlogId = question.BlogId,
                CourseId = question.CourseId,
                SubCategoryId = question.SubCategoryId,
                TestId = question.TestId,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    IsCorrect = answer.IsCorrect,
                }).ToList(),
            }).ToList();

            if (questionDTOs is null || !questionDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No questions found with this SubCategory ID : {id}"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = questionDTOs,
            };
        }

        [HttpGet("test/{id:int}")]
        public ActionResult<GeneralResponse> GetByTestId(int id)
        {
            if (!_standardTestRepository.Exists(id))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No test found with this ID : {id}"
                };
            }

            List<GetQuestionDTO> questionDTOs = _questionRepository.FindAll(criteria: q => q.TestId == id, includes: ["Answers"]).Select(question => new GetQuestionDTO()
            {
                Id = question.Id,
                BlogId = question.BlogId,
                CourseId = question.CourseId,
                SubCategoryId = question.SubCategoryId,
                TestId = question.TestId,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    IsCorrect = answer.IsCorrect,
                }).ToList(),
            }).ToList();

            if (questionDTOs is null || !questionDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No questions found with this Test ID : {id}"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = questionDTOs,
            };
        }

        [HttpGet("course/{id:int}")]
        public ActionResult<GeneralResponse> GetByCourseId(int id)
        {
            if (!_courseRepository.Exists(id))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No course found with this ID : {id}"
                };
            }

            List<GetQuestionDTO> questionDTOs = _questionRepository.FindAll(criteria: q => q.CourseId == id, includes: ["Answers"]).Select(question => new GetQuestionDTO()
            {
                Id = question.Id,
                BlogId = question.BlogId,
                CourseId = question.CourseId,
                SubCategoryId = question.SubCategoryId,
                TestId = question.TestId,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    IsCorrect = answer.IsCorrect,
                }).ToList(),
            }).ToList();

            if (questionDTOs is null || !questionDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No questions found with this course ID : {id}"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = questionDTOs,
            };
        }

        [HttpGet("blog/{id:int}")]
        public ActionResult<GeneralResponse> GetByBlogId(int id)
        {
            if (!_blogRepository.Exists(id))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No blog found with this ID : {id}"
                };
            }

            List<GetQuestionDTO> questionDTOs = _questionRepository.FindAll(criteria: q => q.BlogId == id, includes: ["Answers"]).Select(question => new GetQuestionDTO()
            {
                Id = question.Id,
                BlogId = question.BlogId,
                CourseId = question.CourseId,
                SubCategoryId = question.SubCategoryId,
                TestId = question.TestId,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    IsCorrect = answer.IsCorrect,
                }).ToList(),
            }).ToList();

            if (questionDTOs is null || !questionDTOs.Any())
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No questions found with this blog ID : {id}"
                };
            }

            return new GeneralResponse()
            {
                IsSuccess = true,
                Data = questionDTOs,
            };
        }

    }
}