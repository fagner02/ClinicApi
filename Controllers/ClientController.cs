using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Dtos;
using clinics_api.Models;
using clinics_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace clinics_api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase {
        private readonly ClientService _clientService;
        public ClientController(ClientService clientService) {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll() {
            return Ok(await _clientService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> Get(string cpf) {
            return Ok(await _clientService.Get(cpf));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateClientDto client) {
            await _clientService.Create(client);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string cpf, ClientDto client) {
            if (!await _clientService.Update(cpf, client)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string cpf) {
            if (!await _clientService.Delete(cpf)) {
                return NotFound();
            }
            return NoContent();
        }
    }
}