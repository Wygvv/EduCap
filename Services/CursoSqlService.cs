
using EduCap.Data;
using EduCap.Models;
using Microsoft.EntityFrameworkCore;

namespace EduCap.Services
{
    public class CursoSqlService : ICursoService
    {
        private readonly EduCapDbContext _context;

        public CursoSqlService(EduCapDbContext context)
        {
            _context = context;
        }

        // READ: Obtener todos los cursos
        public async Task<List<Curso>> ObtenerTodosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        // READ: Buscar un curso por su ID
        public async Task<Curso?> ObtenerPorIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        // CREATE: Registrar un curso
        public async Task AgregarAsync(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }

        // UPDATE: Actualizar un curso existente
        public async Task ActualizarAsync(Curso curso)
        {
            var existente = await _context.Cursos.FindAsync(curso.Id);

            if (existente == null)
                return;

            _context.Entry(existente).CurrentValues.SetValues(curso);
            await _context.SaveChangesAsync();
        }

        // DELETE: Eliminar un curso
        public async Task EliminarAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
                return;

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
        }
    }
}
