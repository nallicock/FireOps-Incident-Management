using System;
using System.Collections.Generic;
using System.Text;
using FireOps.Domain.Entities;
using FireOps.Domain.Interfaces;
using FireOps.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FireOps.Infrastructure.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly FireOpsDbContext _context;

        public IncidentRepository(FireOpsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Incident>> GetAllIncsAsync()
        {
            return await _context.Incidents.ToListAsync();
        }

        public async Task<Incident?> GetByIdAsync(int id)
        {
            return await _context.Incidents.FindAsync(id);
        }

        public async Task AddAsync(Incident incident)
        {
            await _context.Incidents.AddAsync(incident);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Incident incident)
        {
            _context.Incidents.Update(incident);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var incident = await _context.Incidents.FindAsync(id);

            if (incident is null)
                return;

            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();
        }
    }
}
