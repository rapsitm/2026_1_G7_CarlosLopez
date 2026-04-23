using lib_servicios.Implementaciones;
using lib_servicios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IAsignaturasAplicacion, AsignaturasAplicacion>();
            services.AddScoped<IEstudiantesAplicacion, EstudiantesAplicacion>();
            services.AddScoped<ISemestresAplicacion, SemestresAplicacion>();
            services.AddScoped<INotasAplicacion, NotasAplicacion>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
			app.MapGet("/", () => "");
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}