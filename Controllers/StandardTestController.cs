using Educational_Medical_platform.DTO.StandardTestDTO;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
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

        private readonly IStandardTestRepository StandardTestRepository;

        public StandardTestController(IStandardTestRepository standardTestRepository)
        {
            this.StandardTestRepository = standardTestRepository;
        }


        [HttpGet]
        public ActionResult<GeneralResponse> GetAllStandardTests()
        {
            try
            {
                var standardTests = StandardTestRepository.FindAll(includes: ["Category", "SubCategory"]);

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
                return  new GeneralResponse
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
                var standardTest = StandardTestRepository.Find(t => t.Id == id , ["Category", "SubCategory"]);

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

                    SubCategoryId = standardTest.SubCategoryId,
                    SubCategoryName = standardTest.SubCategory.Name,

                    CategoryId = standardTest.CategoryId,
                    CategoryName = standardTest.Category.Name
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
                return  new GeneralResponse
                {
                    Message = $"An error occurred while retrieving the Standard Test: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        [HttpPost]
        public ActionResult<GeneralResponse> AddStandardTest([FromBody] StandardTestDTO standardTestDTO)
        {
            try
            {
                if (!ModelState.IsValid )
                {
                    return new GeneralResponse
                    {
                        Message = "Invalid data.",
                        IsSuccess = false
                    };
                }
                var standardTest = new StandardTest
                {
                    Title = standardTestDTO.Title,
                    Fullmark = standardTestDTO.Fullmark,
                    DurationInMinutes = standardTestDTO.DurationInMinutes,
                };

                var createdTest = StandardTestRepository.Add(standardTest);

                StandardTestRepository.save(); 

                var createdTestDTO = new StandardTestDTO
                {
                    Id = createdTest.Id,
                    Title = createdTest.Title,
                    Fullmark = createdTest.Fullmark,
                    DurationInMinutes = createdTest.DurationInMinutes,
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
        public ActionResult<GeneralResponse> UpdateStandardTest(int id, [FromBody] StandardTestDTO standardTestDTO)
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

                var existingTest = StandardTestRepository.GetById(id);

                if (existingTest == null)
                {
                    return new GeneralResponse
                    {
                        Message = "Standard Test not found.",
                        IsSuccess = false
                    };
                }

                existingTest.Title = standardTestDTO.Title;
                existingTest.Fullmark = standardTestDTO.Fullmark;
                existingTest.DurationInMinutes = standardTestDTO.DurationInMinutes;

                 var updatedTest = StandardTestRepository.Update(existingTest);

                 StandardTestRepository.save(); 

                var updatedTestDTO = new StandardTestDTO
                {
                    Id = updatedTest.Id,
                    Title = updatedTest.Title,
                    Fullmark = updatedTest.Fullmark,
                    DurationInMinutes = updatedTest.DurationInMinutes
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
                return  new GeneralResponse
                {
                    Message = $"An error occurred while updating the Standard Test: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> DeleteCategory(int id)
        {
            try
            {
                var existingStandardTest = StandardTestRepository.GetById(id);

                if (existingStandardTest == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Standard Test not found"
                    };
                }

                StandardTestRepository.Delete(existingStandardTest);
                StandardTestRepository.save();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Standard Test deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

    }
}