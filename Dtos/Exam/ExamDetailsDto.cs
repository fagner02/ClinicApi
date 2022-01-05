using System;

namespace clinics_api.Dtos {
    public class ExamDetailsDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Duration { get; set; }
    }
}