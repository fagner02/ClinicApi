using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Models;
using clinics_api.Repositories;

namespace clinics_api.Services {
    public class SchedulingService {
        private readonly SchedulingRepository _scheduling;
        public SchedulingService(SchedulingRepository scheduling) {
            _scheduling = scheduling;
        }

        public async Task<IEnumerable<Scheduling>> GetAll() {
            return await _scheduling.GetAll();
        }

        public async Task Create(Scheduling scheduling) {
            await _scheduling.Create(scheduling);
        }

        public async Task<Scheduling> Get(Guid id) {
            return await _scheduling.Get(id);
        }
    }
}