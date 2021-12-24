using System;

namespace clinics_api.Dtos {
    public class CreateClientDto {
        public string Name { get; set; }
        public string Cpf { get; set; }
        /// <example>
        /// 30/12/2020
        /// </example>
        public string BirthDate { get; set; }
        public Guid AddressId { get; set; }
    }
}