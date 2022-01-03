using System.Collections;
using System.Collections.Generic;
using System;

namespace clinics_api.Dtos {
    public class SchedulingDto {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string ClientCpf { get; set; }
        public IEnumerable<Guid> ExamIds { get; set; }
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