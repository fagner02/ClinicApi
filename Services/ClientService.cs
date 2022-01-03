using System;
using System.Linq;
using System.Collections.Generic;
using clinics_api.Repositories;
using clinics_api.Models;
using System.Threading.Tasks;
using AutoMapper;
using clinics_api.Dtos;
using clinics_api.Enums;

namespace clinics_api.Services {

    public class ClientService : IClientService {
        private readonly ClientRepository _client;
        private readonly IMapper _mapper;
        public ClientService(ClientRepository client, IMapper mapper) {
            _client = client;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientDto>> GetAll() {
            return _mapper.Map<IEnumerable<ClientDto>>(
                (await _client.GetAll()).ToList().Where(x => x.Active));
        }

        public async Task<Response<ClientDto>> GetAllPaged(
            int pageNumber, int pageSize, OrderClientColumn orderColumn, OrderType orderType) {
            var result = await _client.GetAllPaged(pageNumber, pageSize, orderColumn, orderType);
            Response<ClientDto> res = new(result, _mapper.Map<IEnumerable<ClientDto>>(result));
            return res;
        }

        public async Task Create(CreateClientDto client) {
            await _client.Create(_mapper.Map<Client>(client));
        }

        public async Task<ClientDto> Get(string cpf) {
            Client temp = await _client.Get(cpf);
            if (temp != null && !temp.Active) {
                return null;
            }
            return _mapper.Map<ClientDto>(temp);
        }

        public async Task<ClientDto> GetByName(string name) {
            Client temp = await _client.GetByName(name);
            if (temp != null && !temp.Active) {
                return null;
            }
            return _mapper.Map<ClientDto>(temp);
        }

        public async Task<bool> Update(string cpf, UpdateClientDto client) {
            Client temp = await _client.Get(cpf);
            if (temp == null) {
                return false;
            }
            if (!temp.Active) {
                return false;
            }
            temp.AddressId = client.AddressId;
            await _client.Update(temp);
            return true;
        }

        public async Task<bool> Delete(string cpf) {
            Client c = await _client.Get(cpf);
            if (c == null) {
                return false;
            }
            if (!c.Active) {
                return false;
            }
            c.Active = false;
            await _client.Update(c);
            return true;
            // return await _client.Delete(cpf);
        }

        public async Task<ClientDetailsDto> GetDetails(string cpf) {
            Client temp = await _client.GetDetails(cpf);
            if (temp != null && !temp.Active) {
                return null;
            }
            return _mapper.Map<ClientDetailsDto>(temp);
        }
    }
}