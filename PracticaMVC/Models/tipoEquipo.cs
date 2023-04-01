using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class tipoEquipo
    {
        [Key]

        public int id_tipo_equipo { get; set; }

        public string? descripcion { get; set; }

        public int estado { get; set; }
    }
}
