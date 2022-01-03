using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Enums;
using clinics_api.Models;
using X.PagedList;

namespace clinics_api.Repositories {
    public interface IExamRepository {
        Task Create(Exam exam);
        Task<bool> Delete(Guid id);
        Task<Exam> Get(Guid id);
        Task<IEnumerable<Exam>> GetAll();
        Task<IPagedList<Exam>> GetAllPaged(int pageNumber, int pageSize, OrderExamColumn orderColumn, OrderType orderType);
        Task<bool> Update(Guid id, Exam exam);
    }
}