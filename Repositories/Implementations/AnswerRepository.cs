using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class AnswerRepository : GenericRepository<Answer> , IAnswerRepository
    {
        public AnswerRepository(ApplicationDBContext context) : base(context) { }
    }
}