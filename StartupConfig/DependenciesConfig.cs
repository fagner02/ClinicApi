using clinics_api.Repositories;
using clinics_api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace clinics_api.StartupConfig {
    public static class DependenciesConfig {
        public static void AddDependenciesService(this IServiceCollection services) {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<ISchedulingService, SchedulingService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}