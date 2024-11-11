using System.ComponentModel.DataAnnotations;

namespace Taller_en_Clase.Models
{
    public class Estadio
    {
        [Key]
        public int Id { get; set; } 
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int Capacidad { get; set; }

    }
}
