using System;

namespace clinics_api.Dtos {
    public class AddressDto {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Num { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}