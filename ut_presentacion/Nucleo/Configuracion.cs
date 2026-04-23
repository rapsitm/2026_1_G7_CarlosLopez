using Microsoft.Extensions.Configuration;

namespace ut_presentacion.Nucleo
{
    public class Configuracion
    {
        private static IConfiguration? configuration;

        public static string ObtenerValor(string clave)
        {
            if (Configuracion.configuration == null)
            {
                Configuracion.configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build()!;
            }
            return Configuracion.configuration![clave]!;
        }
    }
}