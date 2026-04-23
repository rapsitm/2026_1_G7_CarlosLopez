using lib_servicios.Entidades;
using lib_servicios.Interfaces;

namespace lib_servicios.Implementaciones
{
    public class SemestresAplicacion : ISemestresAplicacion
    {
        private IConexion? IConexion = null;

        public SemestresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public List<Semestres> Listar()
        {
            return this.IConexion!.Semestres!
                .Take(20).ToList();
        }
    }
}
