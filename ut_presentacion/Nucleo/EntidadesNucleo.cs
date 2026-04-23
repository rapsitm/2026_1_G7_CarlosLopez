using lib_servicios.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Asignaturas? Asignaturas()
        {
            var entidad = new Asignaturas();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            return entidad;
        }

        public static Estudiantes? Estudiantes()
        {
            var entidad = new Estudiantes();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Fecha = DateTime.Now;
            return entidad;
        }

        public static Semestres? Semestres()
        {
            var entidad = new Semestres();
            entidad.Descripcion = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            return entidad;
        }

        public static Notas? Notas()
        {
            var entidad = new Notas();
            entidad.Estudiante = 1;
            entidad.Asignatura = 1;
            entidad.Nota1 = 2.4m;
            entidad.Nota2 = 4.5m;
            entidad.Nota3 = 3.8m;
            entidad.Nota4 = 1.7m;
            entidad.Nota5 = 3.7m;
            entidad.Fecha = DateTime.Now;
            return entidad;
        }
    }
}
