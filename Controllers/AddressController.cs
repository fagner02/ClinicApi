
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
    public class AddressController : ControllerBase {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService) {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAdresses() {
            return Ok(await _addressService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetAddress(Guid id) {
            return Ok(await _addressService.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<CreateAddressDto>> Post(CreateAddressDto model) {
            await _addressService.Create(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CreateAddressDto model) {
            if (!await _addressService.Update(id, model)) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressDto>> Delete(Guid id) {
            if (!await _addressService.Delete(id)) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
