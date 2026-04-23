using lib_presentacion.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAsignaturasPresentacion
    {
        Task<List<Asignaturas>> Listar();
    }
}