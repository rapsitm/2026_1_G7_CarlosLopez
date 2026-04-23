using lib_servicios.Entidades;

namespace lib_servicios.Interfaces
{
    public interface IEstudiantesAplicacion
    {
        void Configurar(string StringConexion);
        List<Estudiantes> Listar();
    }
}