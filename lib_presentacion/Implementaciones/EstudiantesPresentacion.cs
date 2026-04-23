using lib_presentacion.Entidades;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class EstudiantesPresentacion : IEstudiantesPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Estudiantes>> Listar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5183/Estudiantes/Listar";

            comunicaciones = new Comunicaciones();
            return await comunicaciones!.Execute<List<Estudiantes>>(datos)!;
        }
    }
}