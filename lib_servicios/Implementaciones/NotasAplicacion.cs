using lib_servicios.Entidades;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios.Implementaciones
{
    public class NotasAplicacion : INotasAplicacion
    {
        private IConexion? IConexion = null;

        public NotasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Notas? Borrar(Notas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Notas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Notas? Guardar(Notas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Notas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Notas> Listar()
        {
            return this.IConexion!.Notas!
                .Include(x => x._Estudiante)
                .Include(x => x._Asignatura)
                .Include(x => x._Semestre)
                .Take(20).ToList();
        }

        public List<Notas> PorEstudiante(Notas? entidad)
        {
            return this.IConexion!.Notas!
                .Include(x => x._Estudiante)
                .Include(x => x._Asignatura)
                .Include(x => x._Semestre)
                .Where(x => x._Estudiante!.Nombre!.Contains(entidad!._Estudiante!.Nombre!))
                .ToList();
        }

        public Notas? Modificar(Notas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Notas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
