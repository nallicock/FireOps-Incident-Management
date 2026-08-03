using System;
using System.Collections.Generic;
using System.Text;
using FireOps.Domain.Interfaces;
using FireOps.Domain.Entities;

namespace FireOps.Infrastructure.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _repository;

        public IncidentService(IIncidentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Incident>> GetAllIncsAsync()
        {
            return await _repository.GetAllIncsAsync();
        }

        public async Task<Incident?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Incident> CreateAsync(Incident incident)
        {
            incident.CreatedAt = DateTime.UtcNow;
            incident.Status = Domain.Enums.IncidentStatus.New;
            await _repository.AddAsync(incident);
            return incident;
        }

        public async Task UpdateAsync(Incident incident)
        {
            await _repository.UpdateAsync(incident);
        }

        public async Task DeleteSync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
