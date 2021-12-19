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
        public async Task<ActionResult<Scheduling>> GetSchedulingById(Guid id) {
            return Ok(await _schedulingService.Get(id));
        }

        [HttpPost]
        public async Task PostScheduling(CreateSchedulingDto model) {
            await _schedulingService.Create(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutScheduling(Guid id, SchedulingDto scheduling) {
            if (!await _schedulingService.Update(id, scheduling)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SchedulingDto>> Delete(Guid id) {
            return await _schedulingService.Get(id);
        }
    }
}