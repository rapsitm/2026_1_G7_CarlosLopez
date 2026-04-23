using asp_servicios.Nucleo;
using lib_servicios.Interfaces;
using lib_servicios.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AsignaturasController : ControllerBase
    {
        private IAsignaturasAplicacion? iAplicacion = null;

        public AsignaturasController(IAsignaturasAplicacion? iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost]
        public List<Asignaturas> Listar()
        {
            if (this.iAplicacion == null)
                throw new Exception("No Injection");

            this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
            return this.iAplicacion!.Listar();
        }
    }
}