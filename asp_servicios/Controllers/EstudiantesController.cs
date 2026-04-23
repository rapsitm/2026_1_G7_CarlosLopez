using asp_servicios.Nucleo;
using lib_servicios.Interfaces;
using lib_servicios.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstudiantesController : ControllerBase
    {
        private IEstudiantesAplicacion? iAplicacion = null;

        public EstudiantesController(IEstudiantesAplicacion? iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost]
        public List<Estudiantes> Listar()
        {
            if (this.iAplicacion == null)
                throw new Exception("No Injection");

            this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
            return this.iAplicacion!.Listar();
        }
    }
}