using System;
using System.Text.Json;

namespace clinics_api.Models {
    public class Client {
        public string Cpf { get; set; }
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public Address AddressObject { get; set; }
    }
}