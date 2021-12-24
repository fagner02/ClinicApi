using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clinics_api.Models;
using clinics_api.Services;
using clinics_api.Dtos;

namespace clinics_api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase {
        private readonly SchedulingService _schedulingService;
        public SchedulingController(SchedulingService schedulingService) {
            _schedulingService = schedulingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchedulingDto>>> GetSchedulings() {
            return Ok(await _schedulingService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchedulingDto>> GetSchedulingById(Guid id) {
            return Ok(await _schedulingService.Get(id));
        }

        [HttpPost]
        public async Task PostScheduling(CreateSchedulingDto scheduling) {
            await _schedulingService.Create(scheduling);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduling(Guid id, UpdateSchedulingDto scheduling) {
            if (!await _schedulingService.Update(id, scheduling)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            if (!await _schedulingService.Delete(id)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}/Details")]
        public async Task<ActionResult<SchedulingDetailsDto>> GetDetails(Guid id) {
            return await _schedulingService.GetDetails(id);
        }
    }
}