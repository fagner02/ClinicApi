using System;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clinics_api.Configs {
    class ClientConfig : IEntityTypeConfiguration<Client> {
        public void Configure(EntityTypeBuilder<Client> builder) {
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.HasKey(x => x.Cpf);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            // builder.OwnsOne(x => x.AddressObject, a => {
            //     a.Property(x => x.Street).HasMaxLength(50);
            //     a.Property(x => x.Num).HasMaxLength(5);
            //     a.Property(x => x.City).HasMaxLength(20);
            //     a.Property(x => x.State).HasMaxLength(20);
            //     a.Property(x => x.ZipCode).HasMaxLength(9);
            // });
            builder.HasOne(x => x.AddressObject).WithMany(x => x.Clients).HasForeignKey(x => x.AddressId).HasPrincipalKey(x => x.Id);
        }
    }
}