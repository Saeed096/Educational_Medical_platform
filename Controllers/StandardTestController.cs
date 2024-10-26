﻿using Educational_Medical_platform.DTO.StandardTestDTO;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using static System.Net.Mime.MediaTypeNames;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardTestController : ControllerBase
    {

        private readonly IStandardTestRepository _standardTestRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public StandardTestController(
            IStandardTestRepository standardTestRepository,
            ISubCategoryRepository subCategoryRepository,
            IQuestionRepository questionRepository,
            IAnswerRepository answerRepository
            )
        {
            _standardTestRepository = standardTestRepository;
            _subCategoryRepository = subCategoryRepository;
            _questionRepository = questionRepository;
            this._answerRepository = answerRepository;
        }

        [HttpGet]
        public ActionResult<GeneralResponse> GetAllStandardTests()
        {
            try
            {
                var standardTests = _standardTestRepository.FindAll(includes: ["Category", "SubCategory"]);

                if (standardTests == null || !standardTests.Any())
                {
                    return new GeneralResponse
                    {
                        Message = "No Standard Tests found.",
                        IsSuccess = false
                    };
                }

                var standardTestDTOs = standardTests.Select(test => new StandardTestDTO
                {
                    Id = test.Id,
                    Title = test.Title,
                    Fullmark = test.Fullmark,
                    DurationInMinutes = test.DurationInMinutes,
                    Price = test.Price,

                    SubCategoryId = test.SubCategoryId,
                    SubCategoryName = test.SubCategory.Name,

                    CategoryId = test.CategoryId,
                    CategoryName = test.Category.Name,

                    Type = test.Type,
                    TypeName = test.Type.GetDisplayName(),

                    Difficulty = test.Difficulty,
                    DifficultyName = test.Difficulty.GetDisplayName(),

                }).ToList();

                return new GeneralResponse
                {
                    Data = standardTestDTOs,
                    Message = "Standard Tests retrieved successfully.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    Message = $"An error occurred while retrieving Standard Tests: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<GeneralResponse> GetStandardTestById(int id)
        {
            try
            {
                var standardTest = _standardTestRepository.Find(t => t.Id == id, ["Category", "SubCategory"]);

                if (standardTest == null)
                {
                    return new GeneralResponse
                    {
                        Message = "Standard Test not found.",
                        IsSuccess = false
                    };
                }

                var standardTestDTO = new StandardTestDTO
                {
                    Id = standardTest.Id,
                    Title = standardTest.Title,
                    Fullmark = standardTest.Fullmark,
                    DurationInMinutes = standardTest.DurationInMinutes,
                    Price = standardTest.Price,

                    SubCategoryId = standardTest.SubCategoryId,
                    SubCategoryName = standardTest.SubCategory.Name,

                    CategoryId = standardTest.CategoryId,
                    CategoryName = standardTest.Category.Name,

                    Difficulty = standardTest.Difficulty,
                    DifficultyName = standardTest.Difficulty.GetDisplayName(),

                    Type = standardTest.Type,
                    TypeName = standardTest.Type.GetDisplayName(),
                };

                return new GeneralResponse
                {
                    Data = standardTestDTO,
                    Message = "Standard Test retrieved successfully.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    Message = $"An error occurred while retrieving the Standard Test: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        [HttpPost]
        public ActionResult<GeneralResponse> AddStandardTest([FromBody] AddTestDTO standardTestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new GeneralResponse
                    {
                        Message = "Invalid data.",
                        IsSuccess = false
                    };
                }

                var subCategory = _subCategoryRepository.Find(s => s.Id == standardTestDTO.SubCategoryId, ["Category"]);

                if (subCategory == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Subcategory not Found !",
                        Status = 404
                    };
                }

                if (subCategory.Type != SubCategoryType.Exams)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Subcategory Type is not Valid for Exams ",
                        Status = 404
                    };
                }

                // Enum validation for Difficulty
                if (!Enum.IsDefined(typeof(TestDifficulty), standardTestDTO.Difficulty))
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid Test Difficulty value.",
                        Status = 400
                    };
                }

                // Enum validation for Type
                if (!Enum.IsDefined(typeof(TestType), standardTestDTO.Type))
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid Test Type value.",
                        Status = 400
                    };
                }

                if (standardTestDTO.Type == TestType.Premium && standardTestDTO.Price <= 0)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Paid Test must have valid price > 0",
                        Status = 400
                    };
                }

                if (standardTestDTO.Type == TestType.Free && standardTestDTO.Price != 0)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Free Test must have valid price = 0",
                        Status = 400
                    };
                }

                var standardTest = new StandardTest
                {
                    Title = standardTestDTO.Title,
                    Fullmark = standardTestDTO.Fullmark,
                    DurationInMinutes = standardTestDTO.DurationInMinutes,
                    Price = standardTestDTO.Price,

                    SubCategoryId = standardTestDTO.SubCategoryId,

                    CategoryId = subCategory.CategoryId,

                    Difficulty = standardTestDTO.Difficulty,

                    Type = standardTestDTO.Type,
                };

                var createdTest = _standardTestRepository.Add(standardTest);

                _standardTestRepository.Save();

                var createdTestDTO = new StandardTestDTO
                {
                    Id = createdTest.Id, // only this from the created obj 

                    Title = standardTest.Title,
                    Fullmark = standardTest.Fullmark,
                    DurationInMinutes = standardTest.DurationInMinutes,
                    Price = createdTest.Price,

                    SubCategoryId = standardTest.SubCategoryId,
                    SubCategoryName = standardTest.SubCategory.Name,

                    CategoryId = standardTest.CategoryId,
                    CategoryName = standardTest.Category.Name,

                    Difficulty = standardTest.Difficulty,
                    DifficultyName = standardTest.Difficulty.GetDisplayName(),

                    Type = standardTest.Type,
                    TypeName = standardTest.Type.GetDisplayName(),
                };

                return new GeneralResponse
                {
                    Data = createdTestDTO,
                    Message = "Standard Test created successfully.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    Message = $"An error occurred while creating the Standard Test: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<GeneralResponse> UpdateStandardTest(int id, [FromBody] AddTestDTO standardTestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new GeneralResponse
                    {
                        Message = "Invalid data or mismatched ID.",
                        IsSuccess = false
                    });
                }

                var subCategory = _subCategoryRepository.Find(s => s.Id == standardTestDTO.SubCategoryId, ["Category"]);

                if (subCategory == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Subcategory not Found !",
                        Status = 404
                    };
                }

                if (subCategory.Type != SubCategoryType.Exams)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Subcategory Type is not Valid for Exams ",
                        Status = 404
                    };
                }

                // Enum validation for Difficulty
                if (!Enum.IsDefined(typeof(TestDifficulty), standardTestDTO.Difficulty))
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid Test Difficulty value.",
                        Status = 400
                    };
                }

                // Enum validation for Type
                if (!Enum.IsDefined(typeof(TestType), standardTestDTO.Type))
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid Test Type value.",
                        Status = 400
                    };
                }

                var existingTest = _standardTestRepository.GetById(id);

                if (existingTest == null)
                {
                    return new GeneralResponse
                    {
                        Message = "Standard Test not found.",
                        IsSuccess = false
                    };
                }


                if (standardTestDTO.Type == TestType.Premium && standardTestDTO.Price <= 0)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Paid Test must have valid price > 0",
                        Status = 400
                    };
                }

                if (standardTestDTO.Type == TestType.Free && standardTestDTO.Price != 0)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Free Test must have valid price = 0",
                        Status = 400
                    };
                }

                existingTest.Title = standardTestDTO.Title;
                existingTest.Fullmark = standardTestDTO.Fullmark;
                existingTest.DurationInMinutes = standardTestDTO.DurationInMinutes;
                existingTest.SubCategoryId = standardTestDTO.SubCategoryId;
                existingTest.CategoryId = subCategory.CategoryId;
                existingTest.Type = standardTestDTO.Type;
                existingTest.Difficulty = standardTestDTO.Difficulty;
                existingTest.Price = standardTestDTO.Price;

                var updatedTest = _standardTestRepository.Update(existingTest);

                _standardTestRepository.Save();

                var updatedTestDTO = new StandardTestDTO
                {
                    Id = updatedTest.Id,
                    Title = standardTestDTO.Title,
                    Fullmark = standardTestDTO.Fullmark,
                    DurationInMinutes = standardTestDTO.DurationInMinutes,
                    Price = standardTestDTO.Price,

                    SubCategoryId = standardTestDTO.SubCategoryId,
                    SubCategoryName = subCategory.Name,

                    CategoryId = subCategory.CategoryId,
                    CategoryName = subCategory.Category.Name,

                    Difficulty = standardTestDTO.Difficulty,
                    DifficultyName = standardTestDTO.Difficulty.GetDisplayName(),

                    Type = standardTestDTO.Type,
                    TypeName = standardTestDTO.Type.GetDisplayName(),
                };

                return new GeneralResponse
                {
                    Data = updatedTestDTO,
                    Message = "Standard Test updated successfully.",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    Message = $"An error occurred while updating the Standard Test: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GeneralResponse>> DeleteTest(int id)
        {
            try
            {
                var existingStandardTest = _standardTestRepository.Find(t => t.Id == id);

                if (existingStandardTest == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Standard Test not found",
                        Status = 404
                    };
                }

                var questions = _questionRepository.FindAll(criteria: q => q.TestId == existingStandardTest.Id, includes: ["Answers"]);

                foreach (var question in questions)
                {
                    _answerRepository.DeleteRange(question.Answers);
                }

                _questionRepository.DeleteRange(questions);

                _standardTestRepository.Delete(existingStandardTest);

                await _standardTestRepository.SaveAsync();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Standard Test and its associated Questions and Answers have been deleted successfully.",
                    Status = 200
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}",
                    Status = 500,
                    Data = ex
                };
            }
        }

    }
}