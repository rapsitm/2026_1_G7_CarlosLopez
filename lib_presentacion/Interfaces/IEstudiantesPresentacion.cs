using lib_presentacion.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEstudiantesPresentacion
    {
        Task<List<Estudiantes>> Listar();
    }
}