using Educational_Medical_platform.DTO.Subcategory;
using Educational_Medical_platform.Models;
using Shoghlana.Core.Interfaces;

namespace Educational_Medical_platform.Repositories.Interfaces
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        bool Exists(int id);

        Task<IEnumerable<GetSubcategoryDTO>> GetSubCategoriesByCategoryIdAsync(int categoryId);

        Task<GetSubcategoryDTO> UpdateSubCategoryAsync(int id, GetSubcategoryDTO subCategoryDTO);

    }
}

