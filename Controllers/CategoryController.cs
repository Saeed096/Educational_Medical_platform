using Educational_Medical_platform.DTO;
using Educational_Medical_platform.DTO.BookDTO;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Implementations;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoghlana.Api.Response;
using System.Collections.Generic;

namespace Educational_Medical_platform.Controllers
{
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
                    //Books = category.Books,
                    //SubCategories = category.SubCategories,
                    //Blogs = category.Blogs
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


        [HttpGet("{id}")]
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

                       
                    };

                    Category addedCategory = CategoryRepository.Add(category);
                    CategoryRepository.save(); 

                    CategoryDTO addedCategoryDTO = new CategoryDTO
                    {
                        Name = addedCategory.Name,
                      
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


        [HttpPut("{id}")]
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

                    CategoryRepository.Update(existingCategory);
                    CategoryRepository.save(); 

                    CategoryDTO updatedCategoryDTO = new CategoryDTO
                    {
                        Name = existingCategory.Name,
                     
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


        [HttpDelete("{id}")]
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
                CategoryRepository.save(); 

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