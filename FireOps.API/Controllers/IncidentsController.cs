using FireOps.Domain.Interfaces;
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
        public async Task<IActionResult> GetAll()
        {
            var incidents = await _incidentService.GetAllIncsAsync();

            return Ok(incidents);
        }
    }
}
