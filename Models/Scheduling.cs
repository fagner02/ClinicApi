using System.Collections;
using System.Collections.Generic;
using System;

namespace clinics_api.Models {
    public class Scheduling {
        public Scheduling() {
            Id = Guid.NewGuid();
            if (_exams == null) {
                return;
            }
            FinalDate = InitialDate;
            foreach (Exam e in _exams) {
                FinalDate += e.Duration;
                Price += e.Price;
            }
        }
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public string ClientCpf { get; set; }
        private IEnumerable<Exam> _exams;
        public IEnumerable<Exam> Exams {
            get {
                return _exams;
            }
            set {
                _exams = value;

                FinalDate = _initialDate;
                foreach (Exam e in value) {
                    FinalDate += e.Duration;
                    Price += e.Price;
                }
            }
        }
        public double Price { get; set; } = 0;
        public IEnumerable<Guid> ExamIds { get; set; }
        public DateTime Date { get; set; }
        private TimeSpan _initialDate;
        public TimeSpan InitialDate {
            get {
                return _initialDate;
            }
            set {
                FinalDate -= _initialDate;
                _initialDate = value;
                if (_initialDate.TotalHours > 23.98) {
                    _initialDate = new TimeSpan(23, 59, 0);
                }
                FinalDate += value;
            }
        }
        public TimeSpan FinalDate { get; set; }
    }
}