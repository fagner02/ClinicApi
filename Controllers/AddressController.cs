
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using clinics_api.Models;
using clinics_api.Services;
using clinics_api.Dtos;
using clinics_api.Enums;

namespace clinics_api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService) {
            _addressService = addressService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAdresses() {
            return Ok(await _addressService.GetAll());
        }

        [HttpGet("Paged")]
        public async Task<ActionResult> GetAdressesPaged(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string search,
            [FromQuery] OrderAddressColumn orderColumn,
            [FromQuery] OrderType orderType = OrderType.ASC) {
            return Ok(await _addressService.GetAllPaged(pageNumber, pageSize, search, orderColumn, orderType));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetAddress(Guid id) {
            AddressDto address = await _addressService.Get(id);
            if (address == null) {
                return NotFound();
            }
            return Ok(address);
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
