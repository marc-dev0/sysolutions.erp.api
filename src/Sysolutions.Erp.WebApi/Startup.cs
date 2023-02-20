using Sysolutions.Erp.Application.Extensions;
using Sysolutions.Erp.Infrastructure.Extensions;
using Sysolutions.Erp.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sysolutions.Erp.WebApi
{
    public class Startup
    {
        readonly string MyAllowAnyOrigin = "_AllowAnyOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowAnyOrigin,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader() //.AllowCredentials()
                    );
            });

            services.AddInjectionInfrastructure(Configuration);
            services.AddInjectionApplication(Configuration);
            services.AddAuthentication(Configuration);
            services.AddControllerVersion();

            services.AddControllers();
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Sysolutions.Erp.WebApi v1");
                c.SwaggerEndpoint("../swagger/v2/swagger.json", "Sysolutions.Erp.WebApi v2");
            });

            app.UseHttpsRedirection();
            app.UseCors(MyAllowAnyOrigin);
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
