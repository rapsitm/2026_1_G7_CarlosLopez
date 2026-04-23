namespace asp_servicios.Nucleo
{
    public class Configuracion
    {
        public static string ObtenerValor(string clave)
        {
            return Startup.Configuration![clave]!;
        }
    }
}