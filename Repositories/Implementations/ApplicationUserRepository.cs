using Educational_Medical_platform.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;
using System.Linq.Expressions;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public PaginatedListDTO<ApplicationUser> FindPaginatedUsers(int page, int pageSize, Expression<Func<ApplicationUser, bool>> criteria = null)
        {
            IQueryable<ApplicationUser> query = _userManager.Users;

            if (criteria != null)
            {
                query = query.Where(criteria);
            }

            int totalFilteredItems = query.Count();

            if (page < 1)
            {
                page = 1;
            }

            int totalPages = (int)Math.Ceiling(totalFilteredItems / (double)pageSize);

            if (page > totalPages)
            {
                page = totalPages;
            }

            var items = query.Skip((page - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PaginatedListDTO<ApplicationUser>
            {
                TotalItems = totalFilteredItems,
                TotalPages = totalPages,
                CurrentPage = page,
                Items = items
            };
        }
    }
}
