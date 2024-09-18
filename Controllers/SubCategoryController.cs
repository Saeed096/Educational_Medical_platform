using Educational_Medical_platform.DTO;
using Educational_Medical_platform.DTO.SubCategoryDTO;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository SubCategoryRepository;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository)
        {
            SubCategoryRepository = subCategoryRepository;
        }

        [HttpGet("GetAllSubCategories")]
        public ActionResult<GeneralResponse> GetAllSubCategories()
        {
            try
            {
                List<SubCategory> Subcategories = (List<SubCategory>)SubCategoryRepository.FindAll();

                List<SubCategoryDTO> SubcategoriesDTO = Subcategories.Select(Subcategory => new SubCategoryDTO
                {
                    Id = Subcategory.Id,
                    Name = Subcategory.Name,
                    CategoryId=Subcategory.CategoryId,
                   
                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Categories retrieved successfully",
                    Data = SubcategoriesDTO
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

        [HttpGet("Subcategory/{categoryId}")]
        public async Task<ActionResult<GeneralResponse>> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCategories = await SubCategoryRepository.GetSubCategoriesByCategoryIdAsync(categoryId);

            if (subCategories == null || !subCategories.Any())
            {
                return new GeneralResponse
                {
                    IsSuccess = false, 
                    Message= "No subcategories found for the specified category."
                };
            }

            return new GeneralResponse 
            {
             IsSuccess= true,
             Data = subCategories,
            };
        }


        [HttpGet("{id}")]
        public ActionResult<GeneralResponse> GetSubCategoryById(int id)
        {
            try
            {
                var Subcategory = SubCategoryRepository.GetById(id);

                if (Subcategory == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "SubCategory not found"
                    };
                }

                var SubcategoryDTO = new SubCategoryDTO
                {
                    Name = Subcategory.Name,

                };

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "SubCategory retrieved successfully",
                    Data = SubcategoryDTO
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


        [HttpPut("{id}")]
        public async Task<ActionResult<GeneralResponse>> UpdateSubCategory(int id, [FromBody] SubCategoryDTO subCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Invalid Subcategory data"
                };
            }

            var updatedSubCategory = await SubCategoryRepository.UpdateSubCategoryAsync(id, subCategoryDTO);

            if (updatedSubCategory == null)
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Invalid category data"
                };
            }

            return new GeneralResponse
            {
                IsSuccess = true,
                Message = "SubCategory Updated successfully",
                Data = updatedSubCategory
            };
        }


        [HttpPost]
        public ActionResult<GeneralResponse> AddSubCategory([FromBody] SubCategoryDTO SubcategoryDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SubCategory Subcategory = new SubCategory
                    {
                        Name = SubcategoryDTO.Name,
                        CategoryId = SubcategoryDTO.CategoryId,


                    };

                    SubCategory addedSubCategory = SubCategoryRepository.Add(Subcategory);
                    SubCategoryRepository.save();

                    SubCategoryDTO addedSubCategoryDTO = new SubCategoryDTO
                    {
                        Name = addedSubCategory.Name,
                        CategoryId = addedSubCategory.CategoryId,
                        

                    };

                    return new GeneralResponse
                    {
                        IsSuccess = true,
                        Message = "SubCategory added successfully",
                        Data = addedSubCategoryDTO
                    };
                }

                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Invalid Subcategory data"
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

        [HttpDelete("{id}")]
        public ActionResult<GeneralResponse> DeleteSubCategory(int id)
        {
            try
            {
                var existingSubCategory = SubCategoryRepository.GetById(id);

                if (existingSubCategory == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "SubCategory not found"
                    };
                }

                SubCategoryRepository.Delete(existingSubCategory);
                SubCategoryRepository.save();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "SubCategory deleted successfully"
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
