using Educational_Medical_platform.Models;
using Shoghlana.Core.Interfaces;

namespace Educational_Medical_platform.Repositories.Interfaces
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        public bool Exists(int id);
    }
}
