using lib_servicios.Entidades;

namespace lib_servicios.Interfaces
{
    public interface IAsignaturasAplicacion
    {
        void Configurar(string StringConexion);
        List<Asignaturas> Listar();
    }
}