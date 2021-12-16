using Microsoft.EntityFrameworkCore;
using clinics_api.Models;
using clinics_api.Config;

namespace clinics_api.Contexts {
    public class Context : DbContext {
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Client>(new ClientConfig().Configure);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Scheduling> Schedulings { get; set; }
    }
}