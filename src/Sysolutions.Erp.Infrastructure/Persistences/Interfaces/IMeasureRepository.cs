﻿using Sysolutions.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Infrastructure.Persistences.Interfaces
{
    public interface IMeasureRepository
    {
        Task<IEnumerable<Measure>> GetAllAsync();
        Task<bool> InsertAsync(Measure request);
    }
}
