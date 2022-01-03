using System.Collections;
using System.Collections.Generic;
using System;
using clinics_api.Models;

namespace clinics_api.Dtos {
    public class SchedulingDetailsDto {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public IEnumerable<ExamDto> Exams { get; set; }
        public ClientDto Client { get; set; }
        /// <example>
        /// 30/12/2020
        /// </example>
        public string Date { get; set; }
        /// <example>
        /// 00:00
        /// </example>
        public string InitialDate { get; set; }
        /// <example>
        /// 00:00
        /// </example>
        public string FinalDate { get; set; }
    }
}