using lib_servicios.Entidades;
using lib_servicios.Interfaces;

namespace lib_servicios.Implementaciones
{
    public class AsignaturasAplicacion : IAsignaturasAplicacion
    {
        private IConexion? IConexion = null;

        public AsignaturasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Asignaturas> Listar()
        {
            return this.IConexion!.Asignaturas!
                .Take(20).ToList();
        }
    }
}
