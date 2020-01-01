using PremierLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Services
{
    public interface IEquiposService
    {
        Task<IEnumerable<Equipo>> GetEquiposAsync(bool showJugadores, string orderBy);
        Task<Equipo> GetEquipoAsync(int id, bool showJugadores);
        Task<Equipo> CreateEquipoAsync(Equipo newEquipo);
        Task<bool> DeleteEquipoAsync(int id);
        Task<Equipo> UpdateEquipoAsync(int id, Equipo newEquipo);
    }
}
