using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Models;
using X.PagedList;
using clinics_api.Enums;
using System.Linq.Expressions;
using System;

namespace clinics_api.Repositories {
    public interface IClientRepository {
        Task Create(Client client);
        Task<bool> Delete(string cpf);
        Task<Client> Get(string cpf, Expression<Func<Client, bool>> predicate);
        Task<IEnumerable<Client>> GetAll();
        Task<IPagedList<Client>> GetAllPaged(int pageNumber, int pageSize, OrderClientColumn searchColumn, string search, OrderClientColumn orderColumn, OrderType orderType);
        Task<Client> GetDetails(string cpf);
        Task<bool> Update(Client Client);
    }
}