using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Enums;
using clinics_api.Models;
using X.PagedList;

namespace clinics_api.Repositories {
    public interface IAddressRepository {
        Task Create(Address address);
        Task<bool> Delete(Guid id);
        Task<Address> Get(Guid id);
        Task<IEnumerable<Address>> GetAll();
        Task<IPagedList<Address>> GetAllPaged(int pageNumber, int pageSize, string search, OrderAddressColumn orderColumn, OrderType orderType);
        Task<bool> Update(Guid id, Address address);
    }
}