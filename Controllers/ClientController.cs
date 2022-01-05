using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Dtos;
using clinics_api.Enums;
using clinics_api.Models;
using clinics_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace clinics_api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService) {
            _clientService = clientService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll() {
            return Ok(await _clientService.GetAll());
        }

        [HttpGet("Paged")]
        public async Task<ActionResult> GetAllPaged(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] OrderClientColumn searchColumn,
            [FromQuery] string search,
            [FromQuery] OrderClientColumn orderColumn,
            [FromQuery] OrderType orderType = OrderType.ASC) {
            return Ok(await _clientService.GetAllPaged(pageNumber, pageSize, searchColumn, search, orderColumn, orderType));
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<ClientDto>> Get(string cpf) {
            return Ok(await _clientService.Get(cpf));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ClientDto>> GetByName(string name) {
            return Ok(await _clientService.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateClientDto client) {
            await _clientService.Create(client);
            return Ok();
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> Put(string cpf, UpdateClientDto client) {
            if (!await _clientService.Update(cpf, client)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        public async Task<ActionResult> Delete(string cpf) {
            if (!await _clientService.Delete(cpf)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{cpf}/Details")]
        public async Task<ActionResult<ClientDetailsDto>> GetDetails(string cpf) {
            return await _clientService.GetDetails(cpf);
        }
    }
}