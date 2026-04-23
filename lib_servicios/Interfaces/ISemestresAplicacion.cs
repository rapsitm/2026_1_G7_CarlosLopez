using lib_servicios.Entidades;

namespace lib_servicios.Interfaces
{
    public interface ISemestresAplicacion
    {
        void Configurar(string StringConexion);
        List<Semestres> Listar();
    }
}