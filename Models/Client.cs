using System.Collections.Generic;
using System;
using System.Text.Json;

namespace clinics_api.Models {
    public class Client {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public DateTime BirthDate { get; set; }
        public Address AddressObject { get; set; }
        public Guid? AddressId { get; set; }
        public IEnumerable<Scheduling> Schedulings { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}