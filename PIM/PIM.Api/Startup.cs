using Extension.Core.Extensions;
using PIM.Api.Services;

namespace PIM.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // passar a string de conexão do banco de dados
            services.AddHttpServices("Server=localhost;Database=PIM;Trusted_Connection=True;");
            services.AddServices();
            services.AddScoped<PIMServices>();
            services.AddControllers();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(x =>
            {
                x.MapControllers();
            });
        }
    }
}
