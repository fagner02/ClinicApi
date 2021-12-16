using System.Collections.Generic;
using clinics_api.Repositories;
using clinics_api.Models;
using System.Threading.Tasks;

namespace clinics_api.Services {
    public class ClientService {
        private readonly ClientRepository _client;
        public ClientService(ClientRepository client) {
            _client = client;
        }
        public async Task<IEnumerable<Client>> GetAll() {
            return await _client.GetAll();
        }

        public async Task Create(Client client) {
            await _client.Create(client);
        }
    }
}