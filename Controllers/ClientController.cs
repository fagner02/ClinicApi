using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<Client>>> GetAll() {
            return Ok(await _clientService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Client client) {
            Console.WriteLine(client.AddressObject.City);
            await _clientService.Create(client);
            return Ok();
        }
    }
}