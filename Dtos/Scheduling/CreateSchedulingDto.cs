using System.Collections;
using System.Collections.Generic;
using System;

namespace clinics_api.Dtos {
    public class CreateSchedulingDto {
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
    }
}