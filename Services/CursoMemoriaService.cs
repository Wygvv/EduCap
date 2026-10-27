
using EduCap.Models;

namespace EduCap.Services
{
    public class CursoMemoriaService : ICursoService
    {
        private readonly List<Curso> _cursos = new();
        private int _siguienteId = 1;

        public Task<List<Curso>> ObtenerTodosAsync()
        {
            return Task.FromResult(_cursos.ToList());
        }

        public Task<Curso?> ObtenerPorIdAsync(int id)
        {
            return Task.FromResult(
                _cursos.FirstOrDefault(c => c.Id == id)
            );
        }

        public Task AgregarAsync(Curso curso)
        {
            curso.Id = _siguienteId++;
            _cursos.Add(curso);

            return Task.CompletedTask;
        }

        public Task ActualizarAsync(Curso curso)
        {
            var existente = _cursos.FirstOrDefault(c => c.Id == curso.Id);

            if (existente != null)
            {
                existente.Nombre = curso.Nombre;
                existente.Descripcion = curso.Descripcion;
                existente.Categoria = curso.Categoria;
                existente.DuracionHoras = curso.DuracionHoras;
                existente.Modalidad = curso.Modalidad;
                existente.Cupos = curso.Cupos;
                existente.FechaInicio = curso.FechaInicio;
            }

            return Task.CompletedTask;
        }

        public Task EliminarAsync(int id)
        {
            var curso = _cursos.FirstOrDefault(c => c.Id == id);

            if (curso != null)
            {
                _cursos.Remove(curso);
            }

            return Task.CompletedTask;
        }
    }
}
