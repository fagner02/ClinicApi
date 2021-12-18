using System;

namespace clinics_api.Dtos {
    public class ClientDto {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address {get; set;}
    }
}