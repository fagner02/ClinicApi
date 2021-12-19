using System.Linq;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clinics_api.Configs {
    public class ExamConfig : IEntityTypeConfiguration<Exam> {
        public void Configure(EntityTypeBuilder<Exam> builder) {
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Price).IsRequired();
            //builder.HasMany<Scheduling>().WithOne().HasForeignKey(x => x.ExamIds.FirstOrDefault());
        }
    }
}