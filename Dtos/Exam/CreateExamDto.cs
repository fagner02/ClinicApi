using System;
using System.ComponentModel;

namespace clinics_api.Dtos {
    public class CreateExamDto {
        public string Name { get; set; }
        public double Price { get; set; }
        /// <example>
        /// 00:00
        /// </example>
        public string Duration { get; set; }
    }
}