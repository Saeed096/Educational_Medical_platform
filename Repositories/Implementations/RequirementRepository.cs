using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class RequirementRepository : GenericRepository<Requirement> ,IRequirementRepository
    {

        public RequirementRepository(ApplicationDBContext context) : base(context)
        {
            
        }
    }
}
