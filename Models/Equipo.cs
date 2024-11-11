using System.ComponentModel.DataAnnotations;

namespace Taller_en_Clase.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public string Ciudad {  get; set; }
        public string Titulos { get; set; }
        public bool? AceptaExtranjeros { get; set; }

    }
}
