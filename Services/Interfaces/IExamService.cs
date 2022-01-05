using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Dtos;
using clinics_api.Models;
using clinics_api.Enums;

namespace clinics_api.Services {
    public interface IExamService {
        Task Create(CreateExamDto exam);
        Task<bool> Delete(Guid id);
        Task<ExamDto> Get(Guid id);
        Task<IEnumerable<ExamDto>> GetAll();
        Task<Response<ExamDto>> GetAllPaged(int pageNumber, int pageSize, OrderExamColumn searchColumn, string search, OrderExamColumn orderColumn, OrderType orderType);
        Task<bool> Update(Guid id, CreateExamDto exam);
        Task<ExamDetailsDto> GetDetails(Guid id);
    }
}