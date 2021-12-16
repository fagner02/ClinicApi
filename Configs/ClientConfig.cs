using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clinics_api.Config {
    class ClientConfig : IEntityTypeConfiguration<Client> {
        public void Configure(EntityTypeBuilder<Client> builder) {
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.HasKey(x => x.Cpf);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}