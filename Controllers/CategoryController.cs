using Educational_Medical_platform.DTO;
using Educational_Medical_platform.Helpers;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;

namespace Educational_Medical_platform.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryController(ICategoryRepository _categoryRepository)
        {
            CategoryRepository = _categoryRepository;
        }

        [HttpGet("GetAllCategories")]
        public ActionResult<GeneralResponse> GetAllCategories()
        {
            try
            {
                List<Category> categories = (List<Category>)CategoryRepository.FindAll();

                List<CategoryDTO> categoriesDTO = categories.Select(category => new CategoryDTO
                {
                    Id=category.Id,
                    Name = category.Name,
                    Type = category.Type,


                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Categories retrieved successfully",
                    Data = categoriesDTO
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

        [HttpGet("GetAllCategoriesByTypeCourses")]
        public ActionResult<GeneralResponse> GetAllCategoriesByTypeCourses()
        {
            try
            {
                // Filter categories by Type Courses
                List<Category> categories = (List<Category>)CategoryRepository.FindAll(
                    criteria: category => category.Type == CategoryType.Courses
                );

                List<CategoryDTO> categoriesDTO = categories.Select(category => new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Type = category.Type,

                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Categories retrieved successfully",
                    Data = categoriesDTO
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

        [HttpGet("GetAllCategoriesByTypeBooks")]
        public ActionResult<GeneralResponse> GetAllCategoriesByTypeBooks()
        {
            try
            {
                // Filter categories by Type Courses
                List<Category> categories = (List<Category>)CategoryRepository.FindAll(
                    criteria: category => category.Type == CategoryType.Books
                );

                List<CategoryDTO> categoriesDTO = categories.Select(category => new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Type = category.Type,
                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Categories retrieved successfully",
                    Data = categoriesDTO
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

        [HttpGet("GetAllCategoriesByTypeBlogs")]
        public ActionResult<GeneralResponse> GetAllCategoriesByTypeBlogs()
        {
            try
            {
                // Filter categories by Type Courses
                List<Category> categories = (List<Category>)CategoryRepository.FindAll(
                    criteria: category => category.Type == CategoryType.Blogs
                );

                List<CategoryDTO> categoriesDTO = categories.Select(category => new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Type= category.Type
                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Categories retrieved successfully",
                    Data = categoriesDTO
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
        
        [HttpGet("GetAllCategoriesByTypeExams")]
        public ActionResult<GeneralResponse> GetAllCategoriesByTypeExams()
        {
            try
            {
                // Filter categories by Type Courses
                List<Category> categories = (List<Category>)CategoryRepository.FindAll(
                    criteria: category => category.Type == CategoryType.Exams
                );

                List<CategoryDTO> categoriesDTO = categories.Select(category => new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Type=category.Type,
                }).ToList();

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Categories retrieved successfully",
                    Data = categoriesDTO
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

        [HttpGet("{id:int}")]

        public ActionResult<GeneralResponse> GetCategoryById(int id)
        {
            try
            {
                var category = CategoryRepository.GetById(id);

                if (category == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Category not found"
                    };
                }

                var categoryDTO = new CategoryDTO
                {
                    Name = category.Name,
                    Type = category.Type,
                  
                };

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Category retrieved successfully",
                    Data = categoryDTO
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

        [HttpPost]
        public ActionResult<GeneralResponse> AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category category = new Category
                    {
                        Name = categoryDTO.Name,
                        Type= categoryDTO.Type,

                       
                    };

                    Category addedCategory = CategoryRepository.Add(category);
                    CategoryRepository.Save(); 

                    CategoryDTO addedCategoryDTO = new CategoryDTO
                    {
                        Name = addedCategory.Name,
                        Type = addedCategory.Type,
                      
                    };

                    return new GeneralResponse
                    {
                        IsSuccess = true,
                        Message = "Category added successfully",
                        Data = addedCategoryDTO
                    };
                }

                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Invalid category data"
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

        [HttpPut("{id:int}")]
        public ActionResult<GeneralResponse> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                var existingCategory = CategoryRepository.GetById(id);

                if (existingCategory == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Category not found"
                    };
                }

                if (ModelState.IsValid)
                {
                    existingCategory.Name = categoryDTO.Name;
                    existingCategory.Type = categoryDTO.Type;

                    CategoryRepository.Update(existingCategory);
                    CategoryRepository.Save(); 

                    CategoryDTO updatedCategoryDTO = new CategoryDTO
                    {
                        Name = existingCategory.Name,
                        Type = existingCategory.Type,
                     
                    };

                    return new GeneralResponse
                    {
                        IsSuccess = true,
                        Message = "Category updated successfully",
                        Data = updatedCategoryDTO
                    };
                }

                return new GeneralResponse
                {
                    IsSuccess = false,
                    Message = "Invalid category data"
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

        [HttpDelete("{id:int}")]
        public ActionResult<GeneralResponse> DeleteCategory(int id)
        {
            try
            {
                var existingCategory = CategoryRepository.GetById(id);

                if (existingCategory == null)
                {
                    return new GeneralResponse
                    {
                        IsSuccess = false,
                        Message = "Category not found"
                    };
                }

                CategoryRepository.Delete(existingCategory);
                CategoryRepository.Save(); 

                return new GeneralResponse
                {
                    IsSuccess = true,
                    Message = "Category deleted successfully"
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