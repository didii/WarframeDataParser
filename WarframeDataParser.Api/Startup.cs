using WarframeDataParser.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace WarframeDataParser.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddCors(options => {
                options?.AddPolicy("AllowAllHeaders", builder => builder?.AllowAnyMethod()?.AllowAnyHeader()?.AllowAnyOrigin());
            });
            services.AddSwaggerGen(cfg => {
                cfg.SwaggerDoc("v1",
                               new Info {
                                   Title = "WarframeDataParser API",
                                   Version = "v1",
                                   Contact = new Contact { Name = "Dieter Van Broeck", Email = "dieter.vbroeck@gmail.com" }
                               });
                cfg.IncludeXmlComments(@"..\xmlDocs\WarframeDataParser.Api.xml");
                cfg.IncludeXmlComments(@"..\xmlDocs\WarframeDataParser.Business.xml");
            });
            services.AddBusinessServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            //TODO: add global exception handler
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(cfg => cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "WarframeDataParser API V1"));
            app.UseCors("AllowAllHeaders");
            app.UseMvc();
        }
    }
}