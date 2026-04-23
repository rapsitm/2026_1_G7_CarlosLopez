using lib_servicios.Entidades;
using lib_servicios.Implementaciones;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{

    
    [TestClass]
    public class EstudiantesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Estudiantes>? lista;
        private Estudiantes? entidad;

        public EstudiantesPrueba()
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
            this.lista = this.iConexion!.Estudiantes!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Estudiantes()!;

            this.iConexion!.Estudiantes!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Nombre = "Pruebas-U-" + DateTime.Now.ToString("yyyyMMddhhmmss");

            var entry = this.iConexion!.Entry<Estudiantes>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Estudiantes!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}