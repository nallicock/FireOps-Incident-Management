using System;
using System.Collections.Generic;
using System.Text;
using FireOps.Domain.Interfaces;

namespace FireOps.Infrastructure.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _repository;

        public IncidentService(IIncidentRepository repository)
        {
            _repository = repository;
        }
    }
}
