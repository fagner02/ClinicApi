using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clinics_api.Models;
using clinics_api.Services;
using clinics_api.Dtos;
using X.PagedList;
using clinics_api.Enums;

namespace clinics_api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase {
        private readonly SchedulingService _schedulingService;
        public SchedulingController(SchedulingService schedulingService) {
            _schedulingService = schedulingService;
        }

        [HttpGet("All")]
        public async Task<ActionResult> GetSchedulings() {
            return Ok(await _schedulingService.GetAll());
        }

        [HttpGet("Paged")]
        public async Task<ActionResult> GetSchedulings(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] OrderSchedulingColumn orderColumn,
            [FromQuery] OrderType orderType = OrderType.ASC) {
            return Ok(await _schedulingService.GetAllPaged(pageNumber, pageSize, orderColumn, orderType));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchedulingDto>> GetSchedulingById(Guid id) {
            return Ok(await _schedulingService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostScheduling(CreateSchedulingDto scheduling) {
            try {
                await _schedulingService.Create(scheduling);
                return Ok();
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
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