using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class estadosEquipo
    {
        [Key]

        public int id_estados_equipo { get; set; }

        public string? descripcion { get; set; }

        public int estado { get; set; }
    }
}
