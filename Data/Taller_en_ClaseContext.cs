using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taller_en_Clase.Models;

namespace Taller_en_Clase.Data
{
    public class Taller_en_ClaseContext : DbContext
    {
        public Taller_en_ClaseContext (DbContextOptions<Taller_en_ClaseContext> options)
            : base(options)
        {
        }

        public DbSet<Taller_en_Clase.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<Taller_en_Clase.Models.Estadio> Estadio { get; set; } = default!;
        public DbSet<Taller_en_Clase.Models.Jugador> Jugador { get; set; } = default!;
    }
}
