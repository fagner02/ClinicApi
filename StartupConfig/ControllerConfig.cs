using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace clinics_api.StartupConfig {
    public static class ControllerConfig {
        public static void AddControllerService(this IServiceCollection services) {
            services
                .AddControllers()
                .AddJsonOptions(
                    options => options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter()
                    ));
        }
    }
}