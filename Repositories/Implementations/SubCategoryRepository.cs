using Educational_Medical_platform.DTO.SubCategoryDTO;
using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDBContext Context) : base(Context)
        {

        }

        public bool Exists(int id)
        {
            return context.SubCategories.Any(c => c.Id == id);
        }

        public async Task<IEnumerable<SubCategoryDTO>> GetSubCategoriesByCategoryIdAsync(int categoryId)
        {
            return await context.SubCategories
                .Where(sc => sc.CategoryId == categoryId)
                .Select(sc => new SubCategoryDTO
                {
                    Name = sc.Name,
                    CategoryId = sc.CategoryId
                }).ToListAsync();
        }

        public async Task<SubCategoryDTO> UpdateSubCategoryAsync(int id, SubCategoryDTO subCategoryDTO)
        {
            var subCategory = await context.SubCategories.FindAsync(id);

            if (subCategory == null)
            {
                return null;  
            }

            subCategory.CategoryId = subCategoryDTO.CategoryId;

            context.SubCategories.Update(subCategory);
            await context.SaveChangesAsync();

            return new SubCategoryDTO
            {
                CategoryId = subCategory.CategoryId
            };
        }
    }
}