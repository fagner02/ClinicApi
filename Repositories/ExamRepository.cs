using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Contexts;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;

namespace clinics_api.Repositories {
    public class ExamRepository {
        private readonly Context _data;
        public ExamRepository(Context data) {
            _data = data;
        }

        public async Task<IEnumerable<Exam>> GetAll() {
            return await _data.Exams.ToListAsync();
        }

        public async Task Create(Exam exam) {
            await _data.Exams.AddAsync(exam);
            await _data.SaveChangesAsync();
        }
    }
}