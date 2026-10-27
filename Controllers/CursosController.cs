
using Microsoft.AspNetCore.Mvc;
using EduCap.Models;
using EduCap.Services;

namespace EduCap.Controllers
{
    public class CursosController : Controller
    {
        // Servicio encargado de gestionar los cursos
        private readonly ICursoService _cursoService;

        // Constructor: recibe el servicio automáticamente
        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // Mostrar catálogo de cursos
        public async Task<IActionResult> Index()
        {
            var cursos = await _cursoService.ObtenerTodosAsync();

            return View(cursos);
        }

        // Mostrar administración de cursos
        public async Task<IActionResult> Administrar()
        {
            var cursos = await _cursoService.ObtenerTodosAsync();

            return View(cursos);
        }


        // Recibir los datos y registrar un nuevo curso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Curso curso)
        {
            // Comprobar que los datos sean válidos
            if (!ModelState.IsValid)
            {
                return View(curso);
            }

            // Guardar el curso mediante el servicio
            await _cursoService.AgregarAsync(curso);

            // Mostrar mensaje de confirmación
            TempData["Mensaje"] = "Curso registrado correctamente.";

            // Regresar a la administración de cursos
            return RedirectToAction(nameof(Administrar));
        }


        // Mostrar formulario para crear un curso
        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Curso());
        }

      
        // Mostrar formulario con los datos actuales del curso
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var curso = await _cursoService.ObtenerPorIdAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // Recibir y guardar los cambios del curso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Curso curso)
        {
            // Comprobar que el ID de la URL coincida con el del formulario
            if (id != curso.Id)
            {
                return BadRequest();
            }

            // Validar los datos ingresados
            if (!ModelState.IsValid)
            {
                return View(curso);
            }

            // Comprobar que el curso exista
            var existente = await _cursoService.ObtenerPorIdAsync(id);

            if (existente == null)
            {
                return NotFound();
            }

            // Actualizar los datos mediante el servicio
            await _cursoService.ActualizarAsync(curso);

            TempData["Mensaje"] = "Curso actualizado correctamente.";

            return RedirectToAction(nameof(Administrar));
        }


        
        // Mostrar la confirmación para eliminar un curso
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var curso = await _cursoService.ObtenerPorIdAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // Confirmar y ejecutar la eliminación
        [HttpPost]
        [ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            // Comprobar que el curso exista
            var curso = await _cursoService.ObtenerPorIdAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            // Eliminar el curso
            await _cursoService.EliminarAsync(id);

            // Mostrar mensaje de confirmación
            TempData["Mensaje"] = "Curso eliminado correctamente.";

            // Volver a la administración
            return RedirectToAction(nameof(Administrar));
        }

    }
}
