using WarframeDataParser.Db.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WarframeDataParser.Db {
    public static class StartupExtensions {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadWriteRepository<>), typeof(ReadWriteRepository<>));
        }
    }
}
