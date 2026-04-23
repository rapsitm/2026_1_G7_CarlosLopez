using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios.Entidades
{
    public class Estudiantes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; }

        [NotMapped] public List<Notas>? Notas { get; set; }
    }
}
