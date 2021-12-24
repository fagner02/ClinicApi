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
        public async Task<Client> Get(string cpf) {
            return await _data.Clients.Include(x => x.AddressObject).FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<bool> Update(string cpf, Client Client) {
            Client temp = await _data.Clients.FirstOrDefaultAsync(x => x.Cpf == cpf);
            if (temp == null) {
                return false;
            }
            _data.Entry(temp).State = EntityState.Detached;
            _data.Clients.Update(Client);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string cpf) {
            Client temp = await _data.Clients.FirstOrDefaultAsync(x => x.Cpf == cpf);
            if (temp == null) {
                return false;
            }
            _data.Clients.Remove(temp);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<Client> GetDetails(string cpf) {
            return await _data.Clients
            .Include(x => x.Schedulings)
            .Include(x => x.AddressObject).FirstOrDefaultAsync(x => x.Cpf == cpf);
        }
    }
}