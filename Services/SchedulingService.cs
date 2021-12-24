using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using clinics_api.Models;
using clinics_api.Repositories;
using clinics_api.Dtos;

namespace clinics_api.Services {
    public class SchedulingService {
        private readonly SchedulingRepository _scheduling;
        private readonly ExamRepository _exam;
        private readonly IMapper _mapper;
        public SchedulingService(IMapper mapper, SchedulingRepository scheduling, ExamRepository exam) {
            _mapper = mapper;
            _scheduling = scheduling;
            _exam = exam;
        }

        public async Task<IEnumerable<SchedulingDto>> GetAll() {
            return _mapper.Map<IEnumerable<SchedulingDto>>(await _scheduling.GetAll());
        }

        public async Task Create(CreateSchedulingDto scheduling) {
            Scheduling temp = _mapper.Map<Scheduling>(scheduling);
            List<Exam> exams = new();
            List<Guid> examIds = scheduling.ExamIds.ToList();
            if ((await _scheduling.GetAll()).ToList().Exists
            (x => {
                if (x.Date.ToShortDateString() != temp.Date.ToShortDateString()) {
                    return false;
                }
                if (temp.InitialDate >= x.InitialDate && temp.FinalDate <= x.FinalDate) {
                    foreach (Guid id in x.ExamIds) {
                        if (temp.ExamIds.Contains(id)) {
                            return true;
                        }
                    }
                    return false;
                }
                return false;
            })) {
                throw new Exception("Scheduling has concurrent scheduling");
            }


            foreach (Guid id in scheduling.ExamIds) {
                Exam e = await _exam.Get(id);

                if (e == null) {
                    examIds.Remove(id);
                    continue;
                }
                exams.Add(e);
            }

            if (exams.Count == 0) {
                throw new Exception("Scheduling couldn't be added cause no valid exam ids were given, ");
            }
            temp.Exams = exams;
            temp.ExamIds = examIds;
            await _scheduling.Create(temp);
        }

        public async Task<SchedulingDto> Get(Guid id) {
            return _mapper.Map<SchedulingDto>(await _scheduling.Get(id));
        }

        public async Task<bool> Update(Guid id, UpdateSchedulingDto scheduling) {
            // Scheduling temp = await _scheduling.Get(id);
            // temp.
            return await _scheduling.Update(id, _mapper.Map<Scheduling>(scheduling));
        }

        public async Task<bool> Delete(Guid id) {
            return await _scheduling.Delete(id);
        }

        public async Task<SchedulingDetailsDto> GetDetails(Guid id) {
            return _mapper.Map<SchedulingDetailsDto>(await _scheduling.GetDetails(id));
        }
    }
}