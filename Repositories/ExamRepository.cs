using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using clinics_api.Contexts;
using clinics_api.Enums;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace clinics_api.Repositories {
    public class ExamRepository {
        private readonly Context _data;
        public ExamRepository(Context data) {
            _data = data;
        }

        public async Task<IEnumerable<Exam>> GetAll() {
            return await _data.Exams.ToListAsync();
        }

        public async Task<IPagedList<Exam>> GetAllPaged(
            int pageNumber, int pageSize,
            OrderExamColumn orderColumn, OrderType orderType
        ) {
            return await _data.Exams
                .OrderBy($"{orderColumn} {orderType}")
                .ToPagedListAsync(pageNumber, pageSize);
        }

        public async Task Create(Exam exam) {
            await _data.Exams.AddAsync(exam);
            await _data.SaveChangesAsync();
        }

        public async Task<Exam> Get(Guid id) {
            return await _data.Exams.FirstOrDefaultAsync(x => x.Id == id);
        }

        internal Task Create(Address address) {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Guid id, Exam exam) {
            Exam temp = await _data.Exams.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Entry(temp).State = EntityState.Detached;
            exam.Id = id;
            _data.Exams.Update(exam);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id) {
            Exam temp = await _data.Exams.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null) {
                return false;
            }
            _data.Exams.Remove(temp);
            await _data.SaveChangesAsync();
            return true;
        }
    }
}