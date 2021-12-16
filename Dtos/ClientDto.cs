using System;

namespace clinics_api.Dtos {
    public class ClientDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
    }
}