using asp_servicios.Nucleo;
using lib_servicios.Interfaces;
using lib_servicios.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NotasController : ControllerBase
    {
        private INotasAplicacion? iAplicacion = null;

        public NotasController(INotasAplicacion? iAplicacion)
        {
            this.iAplicacion = iAplicacion;
        }

        [HttpPost]
        public List<Notas> Listar()
        {
            if (this.iAplicacion == null)
                throw new Exception("No Injection");

            this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
            return this.iAplicacion!.Listar();
        }

        [HttpPost]
        public List<Notas> PorEstudiante(Notas entidad)
        {
            if (this.iAplicacion == null)
                throw new Exception("No Injection");

            this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
            return this.iAplicacion!.PorEstudiante(entidad);
        }

        [HttpPost]
        public Notas Guardar(Notas entidad)
        {
            if (this.iAplicacion == null)
                throw new Exception("No Injection");

            this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
            return this.iAplicacion!.Guardar(entidad)!;
        }

        [HttpPost]
        public Notas Modificar(Notas entidad)
        {
            if (this.iAplicacion == null)
                throw new Exception("No Injection");

            this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
            return this.iAplicacion!.Modificar(entidad)!;
        }

        [HttpPost]
        public Notas Borrar(Notas entidad)
        {
            if (this.iAplicacion == null)
                throw new Exception("No Injection");

            this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
            return this.iAplicacion!.Borrar(entidad)!;
        }
    }
}