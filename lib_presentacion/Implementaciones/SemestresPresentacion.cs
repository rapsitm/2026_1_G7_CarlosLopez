using lib_presentacion.Entidades;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class SemestresPresentacion : ISemestresPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Semestres>> Listar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5183/Semestres/Listar";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<List<Semestres>>(datos)!;
        }
    }
}