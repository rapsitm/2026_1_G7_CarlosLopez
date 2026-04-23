using lib_servicios.Entidades;
using lib_servicios.Implementaciones;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;



namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class NotasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Notas>? lista;
        private Notas? entidad;

        public NotasPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.IsTrue(Guardar());
            Assert.IsTrue(Modificar());
            Assert.IsTrue(Listar());
            Assert.IsTrue(Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Notas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Notas()!;

            this.iConexion!.Notas!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Nota5 =
                (this.entidad.Nota1 + 
                this.entidad.Nota2 +
                this.entidad.Nota3 +
                this.entidad.Nota4 +
                this.entidad.Nota5) / 5;

            var entry = this.iConexion!.Entry<Notas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Notas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}