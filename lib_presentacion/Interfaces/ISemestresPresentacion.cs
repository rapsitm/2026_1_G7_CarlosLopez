using lib_presentacion.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISemestresPresentacion
    {
        Task<List<Semestres>> Listar();
    }
}