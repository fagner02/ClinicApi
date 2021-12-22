using System;
using clinics_api.Models;

namespace clinics_api.Dtos {
    public class ClientDto {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressDto AddressObject { get; set; }
    }
}