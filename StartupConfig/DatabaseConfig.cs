using clinics_api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace clinics_api.StartupConfig {
    public static class DatabaseConfig {
        public static void AddDatabaseService(this IServiceCollection services, IConfiguration Configuration) {
            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContextPool<Context>(
                c => c.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        }
    }
}