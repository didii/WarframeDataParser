using WarframeDataParser.Db.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarframeDataParser.Db.Contexts;

namespace WarframeDataParser.Db {
    public static class StartupExtensions {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration) {
            // Context
            services.AddScoped(s => new Context(configuration.GetConnectionString("local")));

            // Repositories
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadWriteRepository<>), typeof(ReadWriteRepository<>));
        }
    }
}
