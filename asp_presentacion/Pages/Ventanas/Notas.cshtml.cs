using lib_presentacion.Entidades;
using lib_presentacion.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages.Ventanas
{
    public class NotasModel : PageModel
    {
        private INotasPresentacion? INotasPresentacion = null;
        private IAsignaturasPresentacion? IAsignaturasPresentacion = null;
        private IEstudiantesPresentacion? IEstudiantesPresentacion = null;
        private ISemestresPresentacion? ISemestresPresentacion = null;

        public NotasModel(INotasPresentacion iNotasPresentacion, 
            IAsignaturasPresentacion iAsignaturasPresentacion,
            IEstudiantesPresentacion iEstudiantesPresentacion,
            ISemestresPresentacion iSemestresPresentacion)
        {
            try
            {
                this.INotasPresentacion = iNotasPresentacion;
                this.IAsignaturasPresentacion = iAsignaturasPresentacion;
                this.IEstudiantesPresentacion = iEstudiantesPresentacion;
                this.ISemestresPresentacion = iSemestresPresentacion;
                Filtro = new Notas();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Notas? Actual { get; set; }
        [BindProperty] public Notas? Filtro { get; set; }
        [BindProperty] public List<Notas>? Lista { get; set; }
        [BindProperty] public List<Estudiantes>? Estudiantes { get; set; }
        [BindProperty] public List<Asignaturas>? Asignaturas { get; set; }
        [BindProperty] public List<Semestres>? Semestres { get; set; }

        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!._Estudiante = Filtro!._Estudiante ?? new Estudiantes();
                Filtro!._Estudiante.Nombre = Filtro!._Estudiante.Nombre ?? "" ;

                Accion = Enumerables.Ventanas.Listas;
                var task = this.INotasPresentacion!.PorEstudiante(Filtro!);
                task.Wait();
                Lista = task.Result;
                CargarCombox();
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void CargarCombox()
        {
            try
            {
                if (Estudiantes == null || Estudiantes!.Count <= 0)
                {
                    var task = this.IEstudiantesPresentacion!.Listar();
                    task.Wait();
                    Estudiantes = task.Result;
                }
                if (Asignaturas == null || Asignaturas!.Count <= 0)
                {
                    var task = this.IAsignaturasPresentacion!.Listar();
                    task.Wait();
                    Asignaturas = task.Result;
                }
                if (Semestres == null || Semestres!.Count <= 0)
                {
                    var task = this.ISemestresPresentacion!.Listar();
                    task.Wait();
                    Semestres = task.Result;
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Notas();
                Actual.Fecha = DateTime.Now;
                CargarCombox();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
                CargarCombox();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;

                Task<Notas>? task = null;
                if (Actual!.Id == 0)
                    task = this.INotasPresentacion!.Guardar(Actual!)!;
                else
                    task = this.INotasPresentacion!.Modificar(Actual!)!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var task = this.INotasPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}