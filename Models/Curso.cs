
using System;
using System.ComponentModel.DataAnnotations;

namespace EduCap.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int DuracionHoras { get; set; }

        [Required(ErrorMessage = "La modalidad es obligatoria")]
        public string Modalidad { get; set; } = string.Empty;

        [Range(1, 1000)]
        public int Cupos { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
    }
}
