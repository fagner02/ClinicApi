using System;
using System.Collections.Generic;
using clinics_api.Models;

namespace clinics_api.Dtos {
    public class ClientDetailsDto {
        public string Name { get; set; }
        public string Cpf { get; set; }
        /// <example>
        /// 30/12/2020
        /// </example>
        public string BirthDate { get; set; }
        public IEnumerable<SchedulingDto> Schedulings { get; set; }
        public AddressDto AddressObject { get; set; }
    }
}