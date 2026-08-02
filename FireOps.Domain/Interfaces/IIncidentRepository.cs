using System;
using System.Collections.Generic;
using System.Text;
using FireOps.Domain.Entities;

namespace FireOps.Domain.Interfaces
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<Incident>> GetAllIncsAsync();
        Task<Incident?> GetByIdAsync(int id);
        Task AddAsync(Incident incident);
        Task UpdateAsync(Incident incident);
        Task DeleteAsync(int id);
    }
}
