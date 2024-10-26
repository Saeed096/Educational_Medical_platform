using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class UserLocalSubscribtionRepository : GenericRepository<UserLocalSubscribtion>, IUserLocalSubscribtionRepository
    {
        public UserLocalSubscribtionRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}