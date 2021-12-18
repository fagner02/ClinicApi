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
        public SchedulingController() {
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Scheduling>>> GetSchedulings() {
            // TODO: Your code here
            await Task.Yield();

            return new List<Scheduling> { };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Scheduling>> GetSchedulingById(int id) {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPost("")]
        public async Task<ActionResult<Scheduling>> PostScheduling(Scheduling model) {
            return null;
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