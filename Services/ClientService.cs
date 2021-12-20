using System.Collections;
using System.Collections.Generic;
using clinics_api.Repositories;
using clinics_api.Models;
using System.Threading.Tasks;
using AutoMapper;
using clinics_api.Dtos;

namespace clinics_api.Services {
    public class ClientService {
        private readonly ClientRepository _client;
        private readonly IMapper _mapper;
        public ClientService(ClientRepository client, IMapper mapper) {
            _client = client;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientDto>> GetAll() {
            return _mapper.Map<IEnumerable<ClientDto>>(await _client.GetAll());
        }

        public async Task Create(ClientDto client) {
            await _client.Create(_mapper.Map<Client>(client));
        }

        public async Task<ClientDto> Get(string cpf) {
            return _mapper.Map<ClientDto>(await _client.Get(cpf));
        }

        public async Task<bool> Update(string cpf, ClientDto client) {
            return await _client.Update(cpf, _mapper.Map<Client>(client));
        }

        public async Task<bool> Delete(string cpf) {
            Client c = await _client.Get(cpf);
            if (c == null) {
                return false;
            }
            c.Active = true;
            await _client.Update(c.Cpf, c);
            return true;
            // return await _client.Delete(cpf);
        }
    }
}