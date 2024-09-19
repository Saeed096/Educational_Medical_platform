using Educational_Medical_platform.Models;
using Shoghlana.Core.Interfaces;

namespace Educational_Medical_platform.Repositories.Interfaces
{
    public interface IStandardTestRepository : IGenericRepository<StandardTest>
    {
        public bool Exists(int id);
    }
}