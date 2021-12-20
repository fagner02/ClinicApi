using System.Linq;
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
            _data = data;
        }

        public async Task<IEnumerable<Scheduling>> GetAll() {
            var schedulings = await _data.Schedulings.ToListAsync();
            Console.WriteLine("ooo");
            if (schedulings.Count > 0) {
                Console.WriteLine("ooo 1");
                if (schedulings.ToList()[0].Exams.ToList().Count > 0) {
                    Console.WriteLine("ooo 2" + schedulings.ToList()[0].Exams.ToList()[0].Name);
                }

            }

            return await _data.Schedulings.ToListAsync();
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
            _data.Entry(temp).State = EntityState.Detached;
            _data.Schedulings.Update(scheduling);
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
    }
}