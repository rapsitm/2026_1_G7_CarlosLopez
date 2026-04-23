using lib_presentacion.Entidades;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class NotasPresentacion : INotasPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Notas>> Listar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5183/Notas/Listar";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<List<Notas>>(datos)!;
        }

        public async Task<List<Notas>> PorEstudiante(Notas? entidad)
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Url"] = "http://localhost:5183/Notas/PorEstudiante";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<List<Notas>>(datos)!;
        }

        public async Task<Notas?> Guardar(Notas? entidad)
        {
            if (entidad!.Id != 0)
                throw new Exception("Falta Informacion");

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Url"] = "http://localhost:5183/Notas/Guardar";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<Notas>(datos)!;
        }

        public async Task<Notas?> Modificar(Notas? entidad)
        {
            if (entidad!.Id == 0)
                throw new Exception("Falta Informacion");

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Url"] = "http://localhost:5183/Notas/Modificar";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<Notas>(datos)!;
        }

        public async Task<Notas?> Borrar(Notas? entidad)
        {
            if (entidad!.Id == 0)
                throw new Exception("Falta Informacion");

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Url"] = "http://localhost:5183/Notas/Borrar";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<Notas>(datos)!;
        }
    }
}