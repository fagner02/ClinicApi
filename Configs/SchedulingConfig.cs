using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clinics_api.Configs {
    public class SchedulingConfig : IEntityTypeConfiguration<Scheduling> {
        public void Configure(EntityTypeBuilder<Scheduling> builder) {
            builder.HasOne(x => x.Client);
            builder.HasMany(x => x.Exams);
        }
    }
}