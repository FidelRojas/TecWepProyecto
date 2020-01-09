using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Data.Entities
{
    public class JugadorEntity
    {
        [Key]
        [Required]
        public int? id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string pais { get; set; }
        public int altura { get; set; }
        public int numero { get; set; }
        public string posicion { get; set; }
        public int goles { get; set; }


        [ForeignKey("equipoId")]
        public virtual EquipoEntity Equipo { get; set; }

    }
}
