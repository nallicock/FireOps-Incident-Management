using FireOps.Domain.Interfaces;
using FireOps.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FireOps.API.DTOs;

namespace FireOps.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        //GET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
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
            var incident = await _incidentService.GetByIdAsync(id);

            if (incident == null)
                return NotFound();

            return Ok(incident);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Incident incident)
        {
            var updated = await _incidentService.UpdateAsync(id, incident);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _incidentService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
