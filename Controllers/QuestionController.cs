using Educational_Medical_platform.DTO.Answer;
using Educational_Medical_platform.DTO.Question;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using Shoghlana.Core.Models;
using System.Security.Claims;

namespace Educational_Medical_platform.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IStandardTestRepository _standardTestRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionController(IQuestionRepository questionRepository,
            ISubCategoryRepository subCategoryRepository,
            IBlogRepository blogRepository,
            IStandardTestRepository standardTestRepository,
            ICourseRepository courseRepository,
            IAnswerRepository answerRepository , 
            UserManager<ApplicationUser> userManager)
        {
            _questionRepository = questionRepository;
            _subCategoryRepository = subCategoryRepository;
            _blogRepository = blogRepository;
            _standardTestRepository = standardTestRepository;
            _courseRepository = courseRepository;
            _answerRepository = answerRepository;
            this._userManager = userManager;
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
                Description = question.Description,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    Reason = answer.Reason,
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
                Description = question.Description,

                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    Reason = answer.Reason,
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
                Description = question.Description,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    Reason = answer.Reason,
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
        public async Task<ActionResult<GeneralResponse>> GetByTestId(int id)
        {
            var test = _standardTestRepository.GetById(id);

            if (test is null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No test found with this ID : {id}"
                };
            }


            if(test.Type == TestType.Premium)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = await _userManager.FindByIdAsync(userId);

                var userRoles = await _userManager.GetRolesAsync(user);

                // Check if the user is allowed access to premium tests
                if (!userRoles.Contains("Admin") && !user.IsSubscribedToPlatform)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "this user can't access premuim test questions because he is not subsciped to platform or Admin",
                        Data = userId
                    };
                }
            }

            List<GetQuestionDTO> questionDTOs = _questionRepository.FindAll(criteria: q => q.TestId == id, includes: ["Answers"])
                .Select(question => new GetQuestionDTO()
                {
                    Id = question.Id,
                    BlogId = question.BlogId,
                    CourseId = question.CourseId,
                    SubCategoryId = question.SubCategoryId,
                    TestId = question.TestId,
                    Description = question.Description,


                    // I think this is better preformance than seeraching every time with questiong ID
                    Answers = question.Answers.Select(answer => new GetAnswerDTO()
                    {
                        Id = answer.Id,
                        QuestionId = answer.QuestionId,
                        Description = answer.Description,
                        Reason = answer.Reason,
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
                Description = question.Description,

                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    Reason = answer.Reason,
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
                Description = question.Description,


                // I think this is better preformance than seeraching every time with questiong ID
                Answers = question.Answers.Select(answer => new GetAnswerDTO()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Description = answer.Description,
                    Reason = answer.Reason,
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

        [HttpPost("subcategory/{subcategoryId:int}")]
        public async Task<ActionResult<GeneralResponse>> AddQuestionForSubCategory(AddQuestionDTO questionDTO, int subcategoryId)
        {
            if (!_subCategoryRepository.Exists(subcategoryId))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No subcategory found for ID: {subcategoryId}",
                    Status = 404
                };
            }

            int correctAnswerCount = questionDTO.Answers.Count(answer => answer.IsCorrect);

            if (correctAnswerCount == 0)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There must be at least one correct answer.",
                    Status = 400
                };
            }

            if (correctAnswerCount > 1)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There can't be more than one correct answer.",
                    Status = 400
                };
            }

            try
            {
                Question question = new Question
                {
                    Description = questionDTO.Description,
                    SubCategoryId = subcategoryId
                };

                _questionRepository.Add(question);
                await _questionRepository.SaveAsync();

                List<Answer> answers = questionDTO.Answers.Select(a => new Answer
                {
                    Description = a.Description,
                    Reason = a.Reason,
                    IsCorrect = a.IsCorrect,
                    QuestionId = question.Id
                }).ToList();

                _answerRepository.AddRange(answers);
                await _answerRepository.SaveAsync();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Question and it's Answers have been successfully saved.",
                    Status = 200,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "An error occurred while saving the question and answers.",
                    Status = 500,
                    Data = ex

                };
            }

        }

        [HttpPost("test/{testId:int}")]
        public async Task<ActionResult<GeneralResponse>> AddQuestionForTest(AddQuestionDTO questionDTO, int testId)
        {
            if (!_standardTestRepository.Exists(testId))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No Test found for ID: {testId}",
                    Status = 404
                };
            }

            int correctAnswerCount = questionDTO.Answers.Count(answer => answer.IsCorrect);

            if (correctAnswerCount == 0)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There must be at least one correct answer.",
                    Status = 400
                };
            }

            if (correctAnswerCount > 1)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There can't be more than one correct answer.",
                    Status = 400
                };
            }

            try
            {
                Question question = new Question
                {
                    Description = questionDTO.Description,
                    TestId = testId,
                };

                _questionRepository.Add(question);
                await _questionRepository.SaveAsync();

                List<Answer> answers = questionDTO.Answers.Select(a => new Answer
                {
                    Description = a.Description,
                    Reason = a.Reason,
                    IsCorrect = a.IsCorrect,
                    QuestionId = question.Id
                }).ToList();

                _answerRepository.AddRange(answers);
                await _answerRepository.SaveAsync();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Question and it's Answers have been successfully saved.",
                    Status = 200,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "An error occurred while saving the question and answers.",
                    Status = 500,
                    Data = ex
                };
            }

        }

        [HttpPost("course/{courseId:int}")]
        public async Task<ActionResult<GeneralResponse>> AddQuestionForCourse(AddQuestionDTO questionDTO, int courseId)
        {
            if (!_courseRepository.Exists(courseId))
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No course found for ID: {courseId}",
                    Status = 404
                };
            }

            int correctAnswerCount = questionDTO.Answers.Count(answer => answer.IsCorrect);

            if (correctAnswerCount == 0)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There must be at least one correct answer.",
                    Status = 400
                };
            }

            if (correctAnswerCount > 1)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There can't be more than one correct answer.",
                    Status = 400
                };
            }

            try
            {
                Question question = new Question
                {
                    Description = questionDTO.Description,
                    CourseId = courseId,
                };

                _questionRepository.Add(question);
                await _questionRepository.SaveAsync();

                List<Answer> answers = questionDTO.Answers.Select(a => new Answer
                {
                    Description = a.Description,
                    Reason = a.Reason,
                    IsCorrect = a.IsCorrect,
                    QuestionId = question.Id
                }).ToList();

                _answerRepository.AddRange(answers);
                await _answerRepository.SaveAsync();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Question and it's Answers have been successfully saved.",
                    Status = 200,
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "An error occurred while saving the question and answers.",
                    Status = 500,
                    Data = ex
                };
            }

        }


        [HttpPatch("{questionId:int}")]
        public async Task<ActionResult<GeneralResponse>> EditQuestion(AddQuestionDTO questionDTO, int questionId)
        {
            var question = _questionRepository.Find(q => q.Id == questionId, includes: ["Answers"]);

            if (question == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No question found for ID: {questionId}",
                    Status = 404
                };
            }

            int correctAnswerCount = questionDTO.Answers.Count(answer => answer.IsCorrect);

            if (correctAnswerCount == 0)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There must be at least one correct answer.",
                    Status = 400
                };
            }

            if (correctAnswerCount > 1)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "There can't be more than one correct answer.",
                    Status = 400
                };
            }

            try
            {
                question.Description = questionDTO.Description;

                _answerRepository.DeleteRange(question.Answers);

                List<Answer> answers = questionDTO.Answers.Select(a => new Answer
                {
                    Description = a.Description,
                    Reason = a.Reason,
                    IsCorrect = a.IsCorrect,
                    QuestionId = question.Id
                }).ToList();

                _answerRepository.AddRange(answers);

                await _questionRepository.SaveAsync();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Message = "Question and its Answers have been successfully updated.",
                    Status = 200
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "An error occurred while updating the question and answers.",
                    Status = 500,
                    Data = ex
                };
            }
        }

        [HttpDelete("{questionId:int}")]
        public async Task<ActionResult<GeneralResponse>> DeleteQuestion(int questionId)
        {
            var question = _questionRepository.Find(q => q.Id == questionId, includes: ["Answers"]);

            if (question == null)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"No question found for ID: {questionId}",
                    Status = 404
                };
            }

            try
            {
                _answerRepository.DeleteRange(question.Answers);

                _questionRepository.Delete(question);

                await _questionRepository.SaveAsync();

                return new GeneralResponse()
                {
                    IsSuccess = true,
                    Message = "Question and its Answers have been successfully deleted.",
                    Status = 200
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Message = "An error occurred while deleting the question and answers.",
                    Status = 500,
                    Data = ex
                };
            }
        }


    }
}