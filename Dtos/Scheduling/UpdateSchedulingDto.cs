using System;
namespace clinics_api.Dtos {
    public class UpdateSchedulingDto {
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