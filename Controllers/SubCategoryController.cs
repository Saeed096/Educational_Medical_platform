using Educational_Medical_platform.DTO;
using Educational_Medical_platform.DTO.SubCategoryDTO;
using Educational_Medical_platform.Helpers;
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
        private readonly ICategoryRepository CategoryRepository;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository, ICategoryRepository _CategoryRepository)
        {
            SubCategoryRepository = subCategoryRepository;
            CategoryRepository = _CategoryRepository;
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
                    CategoryId = Subcategory.CategoryId,

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




        [HttpGet("GetAllSubCategoriesByTypeCourses")]
        public ActionResult<GeneralResponse> GetAllSubCategoriesByTypeCourses()
        {
            try
            {
                // Filter subcategories by Type Courses
                List<SubCategory> subcategories = (List<SubCategory>)SubCategoryRepository.FindAll(
                    criteria: subcategory => subcategory.Type == SubCategoryType.Courses
                );

                List<SubCategoryDTO> subcategoriesDTO = subcategories.Select(subcategory => new SubCategoryDTO
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    CategoryId = subcategory.CategoryId,

                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "SubCategories retrieved successfully",
                    Data = subcategoriesDTO
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


        [HttpGet("GetAllSubCategoriesByTypeBooks")]
        public ActionResult<GeneralResponse> GetAllSubCategoriesByTypeBooks()
        {
            try
            {
                // Filter subcategories by Type Courses
                List<SubCategory> subcategories = (List<SubCategory>)SubCategoryRepository.FindAll(
                    criteria: subcategory => subcategory.Type == SubCategoryType.Books
                );

                List<SubCategoryDTO> subcategoriesDTO = subcategories.Select(subcategory => new SubCategoryDTO
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    CategoryId = subcategory.CategoryId,

                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "SubCategories retrieved successfully",
                    Data = subcategoriesDTO
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
        [HttpGet("GetAllSubCategoriesByTypeBlogs")]
        public ActionResult<GeneralResponse> GetAllSubCategoriesByTypeBlogs()
        {
            try
            {
                // Filter subcategories by Type Courses
                List<SubCategory> subcategories = (List<SubCategory>)SubCategoryRepository.FindAll(
                    criteria: subcategory => subcategory.Type == SubCategoryType.Blogs
                );

                List<SubCategoryDTO> subcategoriesDTO = subcategories.Select(subcategory => new SubCategoryDTO
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    CategoryId = subcategory.CategoryId,

                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "SubCategories retrieved successfully",
                    Data = subcategoriesDTO
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
        [HttpGet("GetAllSubCategoriesByTypeExams")]
        public ActionResult<GeneralResponse> GetAllSubCategoriesByTypeExams()
        {
            try
            {
                // Filter subcategories by Type Courses
                List<SubCategory> subcategories = (List<SubCategory>)SubCategoryRepository.FindAll(
                    criteria: subcategory => subcategory.Type == SubCategoryType.Exams
                );

                List<SubCategoryDTO> subcategoriesDTO = subcategories.Select(subcategory => new SubCategoryDTO
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                    CategoryId = subcategory.CategoryId,

                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "SubCategories retrieved successfully",
                    Data = subcategoriesDTO
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


        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<GeneralResponse>> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCategories = await SubCategoryRepository.GetSubCategoriesByCategoryIdAsync(categoryId);

            if (subCategories == null || !subCategories.Any())
            {
                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "No subcategories found for the specified category."
                };
            }

            return new GeneralResponse
            {
                IsSuccess = true,
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
                    Category category= CategoryRepository.GetById(SubcategoryDTO.CategoryId);

                    SubCategory Subcategory = new SubCategory
                    {
                        Name = SubcategoryDTO.Name,
                        CategoryId = SubcategoryDTO.CategoryId,
                        Type = (SubCategoryType)category.Type

                         
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