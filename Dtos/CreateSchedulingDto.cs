using System.Collections;
using System.Collections.Generic;
using System;

namespace clinics_api.Dtos {
    public class CreateSchedulingDto {
        public Guid Id { get; set; }
        public string ClientCpf { get; set; }
        public IEnumerable<Guid> ExamIds { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan InitialDate { get; set; }
        public TimeSpan FinalDate { get; set; }
    }
}