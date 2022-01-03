using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using clinics_api.Contexts;
using clinics_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using clinics_api.Enums;

namespace clinics_api.Repositories {

    public class SchedulingRepository : ISchedulingRepository {
        private readonly Context _data;
        public SchedulingRepository(Context data) {
            _data = data;
        }

        public async Task<IEnumerable<Scheduling>> GetAll() {
            return await _data.Schedulings.ToListAsync();
        }

        public async Task<IPagedList<Scheduling>> GetAllPaged(
            int pageNumber, int pageSize,
            OrderSchedulingColumn orderColumn, OrderType orderType
        ) {
            return await _data.Schedulings
                .OrderBy($"{orderColumn} {orderType}")
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task Create(Scheduling scheduling) {
            await _data.Schedulings.AddAsync(scheduling);
            await _data.SaveChangesAsync();
        }

        public async Task<Scheduling> Get(Guid id) {
            return await _data.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Guid id, Scheduling scheduling) {
            Scheduling temp = await _data.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            temp.InitialDate = scheduling.InitialDate;
            temp.Date = scheduling.Date;
            _data.Schedulings.Update(temp);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id) {
            Scheduling temp = await _data.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Schedulings.Remove(temp);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<Scheduling> GetDetails(Guid id) {
            return await _data.Schedulings.Include(x => x.Client).Include(x => x.Client.AddressObject).Include(x => x.Exams)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}