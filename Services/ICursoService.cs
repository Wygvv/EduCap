
using EduCap.Models;

namespace EduCap.Services
{
    public interface ICursoService
    {
        Task<List<Curso>> ObtenerTodosAsync();

        Task<Curso?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Curso curso);

        Task ActualizarAsync(Curso curso);

        Task EliminarAsync(int id);
    }
}
