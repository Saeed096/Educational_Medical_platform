using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class Blog_User_LikeRepository : GenericRepository<Blog_User_Likes>, IBlog_User_LikesRepository
    {
        public Blog_User_LikeRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}