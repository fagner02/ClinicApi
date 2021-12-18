using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Contexts;
using clinics_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinics_api.Repositories {
    public class SchedulingRepository {
        private readonly Context _data;
        public SchedulingRepository(Context data) {
            this._data = data;
        }

        public async Task<IEnumerable<Scheduling>> GetAll() {
            return await _data.Schedulings.ToListAsync();
        }

        public async Task Create(Scheduling scheduling) {
            throw new NotImplementedException();
        }

        public async Task<Scheduling> Get(Guid id) {
            return await _data.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}