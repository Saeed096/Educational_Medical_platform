using Shoghlana.Core.DTO;
using Shoghlana.Core.Models;
using System.Linq.Expressions;

namespace Educational_Medical_platform.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        PaginatedListDTO<ApplicationUser> FindPaginatedUsers(int page, int pageSize, Expression<Func<ApplicationUser, bool>> criteria = null);
    }
}