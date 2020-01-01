using PremierLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Services
{
    public interface IJugadoresService
    {
        Task<IEnumerable<Jugador>> GetJugadores(int equipoId);
        Task<Jugador> GetJugadorAsync(int equipoId, int id);
        Task<Jugador> AddJugadorAsync(int equipoId, Jugador jugador);
        Task<Jugador> EditJugadorAsync(int equipoId, int id, Jugador jugador);
        Task<bool> RemoveJugador(int equipoId, int id);
    }
}
