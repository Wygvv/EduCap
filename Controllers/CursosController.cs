
using Microsoft.AspNetCore.Mvc;

namespace EduCap.Controllers
{
    public class CursosController : Controller
    {
        // Página del catálogo de cursos
        public IActionResult Index()
        {
            return View();
        }

        // Página de administración
        public IActionResult Administrar()
        {
            return View();
        }
    }
}
