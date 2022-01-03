using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Models;
using clinics_api.Dtos;
using clinics_api.Enums;

namespace clinics_api.Services {
    public interface ISchedulingService {
        Task Create(CreateSchedulingDto scheduling);
        Task<bool> Delete(Guid id);
        Task<SchedulingDto> Get(Guid id);
        Task<IEnumerable<SchedulingDto>> GetAll();
        Task<Response<SchedulingDto>> GetAllPaged(int pageNumber, int pageSize, OrderSchedulingColumn orderColumn, OrderType orderType);
        Task<SchedulingDetailsDto> GetDetails(Guid id);
        Task<bool> Update(Guid id, UpdateSchedulingDto scheduling);
    }
}