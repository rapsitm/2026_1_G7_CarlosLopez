using System.ComponentModel.DataAnnotations.Schema;

namespace lib_presentacion.Entidades
{
    public class Notas
    {
        public int Id { get; set; }
        public int Estudiante { get; set; }
        public int Asignatura { get; set; }
        public int Semestre { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Nota4 { get; set; }
        public decimal Nota5 { get; set; }
        public decimal NotaFinal { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Estudiante")] public Estudiantes? _Estudiante { get; set; }
        [ForeignKey("Asignatura")] public Asignaturas? _Asignatura { get; set; }
        [ForeignKey("Semestre")] public Semestres? _Semestre { get; set; }
    }
}
