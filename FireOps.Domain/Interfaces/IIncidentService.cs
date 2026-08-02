using FireOps.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireOps.Domain.Interfaces
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetAllIncsAsync();
        Task<Incident?> GetByIdAsync(int id);
        Task<Incident> CreateAsync(Incident incident);
        Task UpdateAsync(Incident incident);
        Task DeleteAsync(int id);
    }
}
