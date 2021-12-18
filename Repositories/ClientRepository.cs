using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using clinics_api.Contexts;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;

namespace clinics_api.Repositories {
    public class ClientRepository {
        private readonly Context _data;
        public ClientRepository(Context data) {
            _data = data;
        }

        public async Task<IEnumerable<Client>> GetAll() {
            return await _data.Clients.Include(x => x.AddressObject).ToListAsync();
        }

        public async Task Create(Client client) {
            await _data.Clients.AddAsync(client);
            await _data.SaveChangesAsync();
        }
    }
}