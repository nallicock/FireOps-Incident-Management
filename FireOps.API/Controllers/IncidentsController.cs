using FireOps.Domain.Interfaces;
using FireOps.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(Incident incident)
        {
            var createdIncident = await _incidentService.CreateAsync(incident);
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdIncident.Id },
                createdIncident);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var incident = await _incidentService.GetByIdAsync(id);

            if (incident == null)
                return NotFound();

            return Ok(incident);
        }
    }
}
