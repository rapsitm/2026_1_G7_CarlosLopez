using lib_servicios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_servicios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        
        DbSet<Estudiantes>? Estudiantes { get; set; }
        DbSet<Asignaturas>? Asignaturas { get; set; }
        DbSet<Semestres>? Semestres { get; set; }
        DbSet<Notas>? Notas { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
