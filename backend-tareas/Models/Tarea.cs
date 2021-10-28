using System.ComponentModel.DataAnnotations;

namespace backend_tareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name can't contain more than 100 characters")]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
