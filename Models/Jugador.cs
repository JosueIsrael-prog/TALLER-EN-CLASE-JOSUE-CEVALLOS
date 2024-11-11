using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller_en_Clase.Models
{
    public class Jugador
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public string posicion { get; set; }
        [Range(16, 40)]
        public int edad { get; set; }
        public Equipo? Equipo { get; set; }
        [ForeignKey("Equipo")]
        public int IdEquipo {get; set;}
    }
}
