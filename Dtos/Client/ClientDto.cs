using System;
using clinics_api.Models;

namespace clinics_api.Dtos {
    public class ClientDto {
        public string Name { get; set; }
        public string Cpf { get; set; }
        /// <example>
        /// 30/12/2020
        /// </example>
        public string BirthDate { get; set; }
        public AddressDto AddressObject { get; set; }
        /// <example>
        /// (XX) XXXXX-XXXX
        /// </example>
        public string Phone { get; set; }
        /// <example>
        /// user@mail.com
        /// </example>
        public string Email { get; set; }
    }
}