using Microsoft.OpenApi.Models;
using System.Configuration;

namespace TasksProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings.BindSettings(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AddSwagger(services);
            services.AddControllers().AddNewtonsoftJson();
            services.AddEndpointsApiExplorer();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var version = AppSettings.Settings.Version;

                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = "Minimal task Api",
                    Version = version,
                    Description = "First Api in Dotnet using EF and learning about deep configuration in a WebApi project"
                });
            });
        }
    }
}
