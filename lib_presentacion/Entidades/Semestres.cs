using System.ComponentModel.DataAnnotations.Schema;

namespace lib_presentacion.Entidades
{
    public class Semestres
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }

        [NotMapped] public List<Notas>? Notas { get; set; }
    }
}
