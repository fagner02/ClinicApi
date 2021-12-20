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
    public class ExamController : ControllerBase {
        private readonly ExamService _examService;
        public ExamController(ExamService examService) {
            _examService = examService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDto>>> GetExams() {
            return Ok(await _examService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamDto>> GetExam(Guid id) {
            return Ok(await _examService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<ExamDto>> PostExam(CreateExamDto exam) {
            await _examService.Create(exam);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CreateExamDto exam) {
            if (!await _examService.Update(id, exam)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            if (!await _examService.Delete(id)) {
                return NotFound();
            }
            return NoContent();
        }
    }
}