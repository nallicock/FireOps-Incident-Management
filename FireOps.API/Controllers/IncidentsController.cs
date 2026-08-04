using Azure.Core;
using FireOps.API.DTOs;
using FireOps.Domain.Entities;
using FireOps.Domain.Interfaces;
using FireOps.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FireOps.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;
        private readonly ILogger<IncidentsController> _logger;
        public IncidentsController(
            IIncidentService incidentService, 
            ILogger<IncidentsController> logger)
        {
            _incidentService = incidentService;
            _logger = logger;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Retrieving all incidents.");

            var incidents = await _incidentService.GetAllIncsAsync();

            return Ok(incidents);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIncidentRequest request)
        {
            var incident = new Incident
            {
                Title = request.Title,
                Description = request.Description
            };

            _logger.LogInformation("Creating incident '{Title}'.", request.Title);

            var createdIncident = await _incidentService.CreateAsync(incident);

            var response = new IncidentResponse
            {
                Id = createdIncident.Id,
                Title = createdIncident.Title,
                Description = createdIncident.Description
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            _logger.LogInformation("Retrieving incident '{id}'.", id);
            var incident = await _incidentService.GetByIdAsync(id);

            if (incident == null)
                return NotFound();

            return Ok(incident);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Incident incident)
        {

            _logger.LogInformation("Updating incident '{id}'.", id);
            var updated = await _incidentService.UpdateAsync(id, incident);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            _logger.LogInformation("Deleting incident '{id}'.", id);
            var deleted = await _incidentService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
