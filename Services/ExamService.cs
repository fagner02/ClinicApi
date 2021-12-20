using System.Buffers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clinics_api.Dtos;
using clinics_api.Models;
using clinics_api.Repositories;
using AutoMapper;

namespace clinics_api.Services {
    public class ExamService {
        private readonly ExamRepository _exam;
        private readonly IMapper _mapper;
        public ExamService(IMapper mapper, ExamRepository exam) {
            _mapper = mapper;
            _exam = exam;
        }
        public async Task<IEnumerable<Exam>> GetAll() {
            return await _exam.GetAll();
        }
        public async Task Create(CreateExamDto exam) {
            await _exam.Create(_mapper.Map<Exam>(exam));
        }

        public async Task<Exam> Get(Guid id) {
            return await _exam.Get(id);
        }

        public async Task<bool> Update(Guid id, CreateExamDto exam) {
            return await _exam.Update(id, _mapper.Map<Exam>(exam));
        }

        public async Task<bool> Delete(Guid id) {
            return await _exam.Delete(id);
        }
    }
}