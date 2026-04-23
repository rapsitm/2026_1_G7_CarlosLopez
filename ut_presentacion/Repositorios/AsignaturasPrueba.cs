using lib_servicios.Entidades;
using lib_servicios.Implementaciones;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;



namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class AsignaturasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Asignaturas>? lista;
        private Asignaturas? entidad;

        public AsignaturasPrueba()
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
            this.lista = this.iConexion!.Asignaturas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Asignaturas()!;

            this.iConexion!.Asignaturas!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Nombre = "Pruebas-U-" + DateTime.Now.ToString("yyyyMMddhhmmss");

            var entry = this.iConexion!.Entry<Asignaturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Asignaturas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}