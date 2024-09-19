using Educational_Medical_platform.Models;
using Shoghlana.Core.Interfaces;

namespace Educational_Medical_platform.Repositories.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course> 
    {
        public bool Exists(int id);
       
    }
}