using System.Collections.Generic;
using System;

namespace clinics_api.Models {
    public class Scheduling {
        Scheduling() {
            FinalDate = InitialDate;
            foreach (Exam x in Exams) {
                FinalDate += x.Duration;
            }
        }
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan InitialDate { get; set; }
        public TimeSpan FinalDate { get; set; }
    }
}