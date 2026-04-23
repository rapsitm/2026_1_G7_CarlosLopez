using lib_servicios.Entidades;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Estudiantes>? Estudiantes { get; set; }
        public DbSet<Asignaturas>? Asignaturas { get; set; }
        public DbSet<Semestres>? Semestres { get; set; }
        public DbSet<Notas>? Notas { get; set; }
    }
}
