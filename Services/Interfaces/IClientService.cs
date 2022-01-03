using System.Collections.Generic;
using clinics_api.Models;
using System.Threading.Tasks;
using clinics_api.Dtos;
using clinics_api.Enums;

namespace clinics_api.Services {
    public interface IClientService {
        Task Create(CreateClientDto client);
        Task<bool> Delete(string cpf);
        Task<ClientDto> Get(string cpf);
        Task<IEnumerable<ClientDto>> GetAll();
        Task<Response<ClientDto>> GetAllPaged(int pageNumber, int pageSize, OrderClientColumn orderColumn, OrderType orderType);
        Task<ClientDto> GetByName(string name);
        Task<ClientDetailsDto> GetDetails(string cpf);
        Task<bool> Update(string cpf, UpdateClientDto client);
    }
}