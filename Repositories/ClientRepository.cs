using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using clinics_api.Contexts;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using clinics_api.Enums;

namespace clinics_api.Repositories {
    public class ClientRepository {
        private readonly Context _data;
        public ClientRepository(Context data) {
            _data = data;
        }

        public async Task<IEnumerable<Client>> GetAll() {
            return await _data.Clients.Include(x => x.AddressObject).ToListAsync();
        }

        public async Task<IPagedList<Client>> GetAllPaged(
            int pageNumber, int pageSize,
            OrderClientColumn orderColumn, OrderType orderType
        ) {
            return await _data.Clients
                .OrderBy($"{orderColumn} {orderType}")
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task Create(Client client) {
            await _data.Clients.AddAsync(client);
            await _data.SaveChangesAsync();
        }
        public async Task<Client> Get(string cpf) {
            return await _data.Clients.Include(x => x.AddressObject).FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<Client> GetByName(string name) {
            return await _data.Clients.Include(x => x.AddressObject).FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> Update(Client Client) {
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