﻿using Educational_Medical_platform.Models;
using Educational_Medical_platform.Repositories.Interfaces;
using Shoghlana.EF;
using Shoghlana.EF.Repository;

namespace Educational_Medical_platform.Repositories.Implementations
{
    public class PlatformRepository : GenericRepository<PlatformData>, IPlatformRepository
    {
        public PlatformRepository(ApplicationDBContext Context) : base(Context)
        {
        }
    }
}