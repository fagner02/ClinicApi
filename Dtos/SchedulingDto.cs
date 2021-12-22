using System.Collections;
using System.Collections.Generic;
using System;

namespace clinics_api.Dtos {
    public class SchedulingDto {
        public Guid Id { get; set; }
        public string ClientCpf { get; set; }
        public IEnumerable<Guid> ExamIds { get; set; }
        public DateTime Date { get; set; }
        public string InitialDate { get; set; } = "00:00";
        public string FinalDate { get; set; } = "00:00";
    }
}