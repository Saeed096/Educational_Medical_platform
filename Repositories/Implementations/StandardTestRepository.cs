﻿using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class StandardTestRepository : GenericRepository<StandardTest>, IStandardTestRepository
    {
        public StandardTestRepository(ApplicationDBContext Context) : base(Context)
        {
        }

        public bool Exists(int id)
        {
            return context.StandardTests.Any(c => c.Id == id);
        }
    }
}