using System;

namespace clinics_api.Dtos {
    public class CreateClientDto {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid AddressId { get; set; }
    }
}