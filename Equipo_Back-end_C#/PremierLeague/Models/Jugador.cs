using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Models
{
    public class Jugador
    {
        public int? id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string pais { get; set; }
        public int altura { get; set; }
        [Range(1, 100)]

        public int numero { get; set; }
        public string posicion { get; set; }

        public int? equipoId { get; set; }

    }
}
