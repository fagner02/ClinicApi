using System;

namespace clinics_api.Models {
    public class Exam {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}