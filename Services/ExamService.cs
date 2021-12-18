using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Models;
using clinics_api.Repositories;

namespace clinics_api.Services {
    public class ExamService {
        private readonly ExamRepository _exam;
        public ExamService(ExamRepository exam) {
            _exam = exam;
        }
        public async Task<IEnumerable<Exam>> GetAll() {
            return await _exam.GetAll();
        }
        public async Task Create(Exam exam) {
            await _exam.Create(exam);
        }
    }
}