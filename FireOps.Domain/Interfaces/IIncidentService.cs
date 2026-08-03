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
        Task<bool> UpdateAsync(int id, Incident incident);
        Task<bool> DeleteAsync(int id);

    }
}
