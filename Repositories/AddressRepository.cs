using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Contexts;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;

namespace clinics_api.Repositories {
    public class AddressRepository {
        private readonly Context _data;
        public AddressRepository(Context data) {
            _data = data;
        }

        public async Task<IEnumerable<Address>> GetAll() {
            return await _data.Addresses.ToListAsync();
        }

        public async Task Create(Address address) {
            await _data.Addresses.AddAsync(address);
            await _data.SaveChangesAsync();
        }

        public async Task<Address> Get(Guid id) {
            return await _data.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Guid id, Address address) {
            Address temp = await _data.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Entry(temp).State = EntityState.Detached;
            address.Id = id;
            _data.Addresses.Update(address);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id) {
            Address temp = await _data.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Addresses.Remove(temp);
            await _data.SaveChangesAsync();
            return true;
        }
    }
}