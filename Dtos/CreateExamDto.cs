using System;

namespace clinics_api.Dtos {
    public class CreateExamDto {
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}