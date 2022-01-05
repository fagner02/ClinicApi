using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Models;
using X.PagedList;
using clinics_api.Enums;

namespace clinics_api.Repositories {
    public interface ISchedulingRepository {
        Task Create(Scheduling scheduling);
        Task<bool> Delete(Guid id);
        Task<Scheduling> Get(Guid id);
        Task<IEnumerable<Scheduling>> GetAll();
        Task<IPagedList<Scheduling>> GetAllPaged(int pageNumber, int pageSize, OrderSchedulingColumn searchColumn, string search, OrderSchedulingColumn orderColumn, OrderType orderType);
        Task<Scheduling> GetDetails(Guid id);
        Task<bool> Update(Guid id, Scheduling scheduling);
    }
}