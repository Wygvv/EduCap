
using Microsoft.EntityFrameworkCore;
using EduCap.Models;

namespace EduCap.Data
{
    public class EduCapDbContext : DbContext
    {
        public EduCapDbContext(DbContextOptions<EduCapDbContext> options)
            : base(options)
        {
        }

        // Tabla de cursos en SQL Server
        public DbSet<Curso> Cursos { get; set; }
    }
}
