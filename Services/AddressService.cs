using System.Collections;
using System.Buffers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Dtos;
using clinics_api.Models;
using clinics_api.Repositories;
using AutoMapper;
using clinics_api.Enums;

namespace clinics_api.Services {

    public class AddressService : IAddressService {
        private readonly IAddressRepository _address;
        private readonly IMapper _mapper;

        public AddressService(IMapper mapper, IAddressRepository address) {
            _mapper = mapper;
            _address = address;
        }

        public async Task<IEnumerable<AddressDto>> GetAll() {
            return _mapper.Map<IEnumerable<AddressDto>>(await _address.GetAll());
        }

        public async Task<Response<AddressDto>> GetAllPaged(
            int pageNumber, int pageSize, string search,
            OrderAddressColumn orderColumn, OrderType orderType
        ) {
            var result = await _address.GetAllPaged(pageNumber, pageSize, search, orderColumn, orderType);
            Response<AddressDto> res = new(result, _mapper.Map<IEnumerable<AddressDto>>(result));
            return res;
        }

        public async Task Create(CreateAddressDto address) {
            await _address.Create(_mapper.Map<Address>(address));
        }

        public async Task<AddressDto> Get(Guid id) {
            return _mapper.Map<AddressDto>(await _address.Get(id));
        }

        public async Task<bool> Update(Guid id, CreateAddressDto address) {
            return await _address.Update(id, _mapper.Map<Address>(address));
        }

        public async Task<bool> Delete(Guid id) {
            return await _address.Delete(id);
        }
    }
}