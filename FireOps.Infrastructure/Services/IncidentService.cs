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

        public async Task<bool> UpdateAsync(int id, Incident incident)
        {
            var existingIncident = await _repository.GetByIdAsync(id);

            if (existingIncident == null)
                return false;

            existingIncident.Title = incident.Title;
            existingIncident.Description = incident.Description;
            
            await _repository.UpdateAsync(existingIncident);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var incident = await _repository.GetByIdAsync(id);

            if (incident == null)
                return false;

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}
