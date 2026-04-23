using lib_servicios.Entidades;

namespace lib_servicios.Interfaces
{
    public interface INotasAplicacion
    {
        void Configurar(string StringConexion);
        List<Notas> PorEstudiante(Notas? entidad);
        List<Notas> Listar();
        Notas? Guardar(Notas? entidad);
        Notas? Modificar(Notas? entidad);
        Notas? Borrar(Notas? entidad);
    }
}