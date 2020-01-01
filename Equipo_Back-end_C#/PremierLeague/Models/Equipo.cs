﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PremierLeague.Models
{
    public class Equipo
    {
        public int? id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string entrenador { get; set; }
        public string info { get; set; }
        public string fundacion { get; set; }
        public string estadio { get; set; }

        public IEnumerable<Jugador> Jugadores { get; set; }
    }
}
