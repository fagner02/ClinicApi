using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clinics_api.Configs {
    public class AddressConfg : IEntityTypeConfiguration<Address> {
        public void Configure(EntityTypeBuilder<Address> builder) {
            builder.Property(x => x.Num).HasMaxLength(5);
            builder.Property(x => x.State).HasMaxLength(20);
            builder.Property(x => x.Street).HasMaxLength(40);
            builder.Property(x => x.ZipCode).HasMaxLength(6);
            builder.Property(x => x.City).HasMaxLength(20);
            builder.Property(x => x.District).HasMaxLength(20);
        }
    }
}