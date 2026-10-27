
using Microsoft.AspNetCore.Mvc;
using EduCap.Models;

namespace EduCap.Controllers
{
    public class CursosController : Controller
    {
        // Mostrar el catálogo de cursos
        public IActionResult Index()
        {
            return View();
        }

        // Mostrar la administración de cursos
        public IActionResult Administrar()
        {
            return View();
        }

        // Mostrar formulario para crear un curso
        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Curso());
        }

        // Mostrar formulario para editar un curso
        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(new Curso { Id = id });
        }

        // Mostrar confirmación para eliminar un curso
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            return View(new Curso { Id = id });
        }
    }
}
