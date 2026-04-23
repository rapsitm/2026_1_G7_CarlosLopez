using lib_presentacion.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface INotasPresentacion
    {
        Task<List<Notas>> Listar();
        Task<List<Notas>> PorEstudiante(Notas? entidad);
        Task<Notas?> Guardar(Notas? entidad);
        Task<Notas?> Modificar(Notas? entidad);
        Task<Notas?> Borrar(Notas? entidad);
    }
}