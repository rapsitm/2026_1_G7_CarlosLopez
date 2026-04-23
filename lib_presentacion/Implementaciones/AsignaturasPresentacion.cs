using lib_presentacion.Entidades;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class AsignaturasPresentacion : IAsignaturasPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Asignaturas>> Listar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5183/Asignaturas/Listar";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<List<Asignaturas>>(datos)!;
        }
    }
}