using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Dtos;
using clinics_api.Models;
using clinics_api.Enums;

namespace clinics_api.Services {
    public interface IAddressService {
        Task Create(CreateAddressDto address);
        Task<bool> Delete(Guid id);
        Task<AddressDto> Get(Guid id);
        Task<IEnumerable<AddressDto>> GetAll();
        Task<Response<AddressDto>> GetAllPaged(int pageNumber, int pageSize, string search, OrderAddressColumn orderColumn, OrderType orderType);
        Task<bool> Update(Guid id, CreateAddressDto address);
    }
}