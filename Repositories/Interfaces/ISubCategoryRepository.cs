using Educational_Medical_platform.DTO.SubCategoryDTO;
using Educational_Medical_platform.Models;
using Shoghlana.Core.Interfaces;

namespace Educational_Medical_platform.Repositories.Interfaces
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {
        bool Exists(int id);

        Task<IEnumerable<SubCategoryDTO>> GetSubCategoriesByCategoryIdAsync(int categoryId);

        Task<SubCategoryDTO> UpdateSubCategoryAsync(int id, SubCategoryDTO subCategoryDTO);

    }
}

