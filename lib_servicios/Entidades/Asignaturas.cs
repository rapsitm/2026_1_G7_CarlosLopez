using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios.Entidades
{
    public class Asignaturas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [NotMapped] public List<Notas>? Notas { get; set; }
    }
}
