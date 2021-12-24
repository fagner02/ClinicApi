using System;
using System.Collections;
using System.Linq;
using clinics_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System.Collections.Generic;

namespace clinics_api.Configs {
    public class SchedulingConfig : IEntityTypeConfiguration<Scheduling> {
        public void Configure(EntityTypeBuilder<Scheduling> builder) {
            builder.HasOne(x => x.Client).WithMany(x => x.Schedulings).HasForeignKey(x => x.ClientCpf);

            // var exams = new ValueConverter<IEnumerable<Exam>, string>(
            // x => JsonSerializer.Serialize(x, x.GetType(), null),
            // x => JsonSerializer.Deserialize<IEnumerable<Exam>>(x, null));

            var examIds = new ValueConverter<IEnumerable<Guid>, string>(
            x => JsonSerializer.Serialize(x, x.GetType(), null),
            x => JsonSerializer.Deserialize<IEnumerable<Guid>>(x, null));

            //builder.Property(x => x.Exams).HasConversion(exams);
            builder.Property(x => x.ExamIds).HasConversion(examIds);
            builder.HasMany(x => x.Exams).WithMany(x => x.Schedulings);
        }
    }
}