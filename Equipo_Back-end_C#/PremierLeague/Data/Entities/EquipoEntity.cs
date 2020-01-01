using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Data.Entities
{
    public class EquipoEntity
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string entrenador { get; set; }
        public string info { get; set; }
        public string fundacion { get; set; }
        public string estadio { get; set; }

        public virtual ICollection<JugadorEntity> Jugadores { get; set; }
    }
}
