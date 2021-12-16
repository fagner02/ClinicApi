using System;

namespace clinics_api.Models {
    public class Client {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}