using lib_servicios.Entidades;
using lib_servicios.Implementaciones;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{

    
    [TestClass]
    public class SemestresPrueba
    {
        private readonly IConexion? iConexion;
        private List<Semestres>? lista;
        private Semestres? entidad;

        public SemestresPrueba()
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
            this.lista = this.iConexion!.Semestres!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Semestres()!;

            this.iConexion!.Semestres!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Descripcion = "Pruebas-U-" + DateTime.Now.ToString("yyyyMMddhhmmss");

            var entry = this.iConexion!.Entry<Semestres>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Semestres!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}