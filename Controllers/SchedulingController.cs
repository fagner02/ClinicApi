using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clinics_api.Models;

namespace clinics_api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase {
        private readonly SchedulingService _schedulingService;
        
        public SchedulingController(SchedulingService schedulingServic) {
            _schedulingService = schedulingServic
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scheduling>>> GetSchedulings() {
            return Ok(await _schedulingService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Scheduling>> GetSchedulingById(int id) {
            
        }

        [HttpPost]
        public async Task<ActionResult<Scheduling>> PostScheduling(Scheduling scheduling) {}
            await _schedulingService.Create(scheduling);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduling(Guid id, Scheduling model) {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Scheduling>> DeleteSchedulingById(Guid id) {
            return null;
        }
    }
}