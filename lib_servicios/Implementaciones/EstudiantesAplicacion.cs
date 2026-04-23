using lib_servicios.Entidades;
using lib_servicios.Interfaces;

namespace lib_servicios.Implementaciones
{
    public class EstudiantesAplicacion : IEstudiantesAplicacion
    {
        private IConexion? IConexion = null;

        public EstudiantesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Estudiantes> Listar()
        {
            return this.IConexion!.Estudiantes!
                .Take(20).ToList();
        }
    }
}
