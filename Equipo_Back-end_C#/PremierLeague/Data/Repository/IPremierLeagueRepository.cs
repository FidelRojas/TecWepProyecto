using PremierLeague.Data.Entities;
using PremierLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Data.Repository
{
    public interface IPremierLeagueRepository
    {
        Task<bool> SaveChangesAsync();

        //equipos
        Task <EquipoEntity> GetEquipoAsync(int id, bool showJugadores = false);
        Task<IEnumerable<EquipoEntity>> GetEquiposAsync(bool showJugadores = false, string orderBy = "id");
        Task DeleteEquipoAsync(int id);
        void UpdateEquipo(EquipoEntity equipo);
        void CreateEquipo(EquipoEntity equipo);



        //jugadores
        Task<IEnumerable<JugadorEntity>> GetJugadoresAsync(int equipoId,string orderBy = "id" );

        IEnumerable<Jugador> GetJugadores();
        Task<JugadorEntity> GetJugadorAsync(int id, bool showJugador = false);
        void CreateJugador(JugadorEntity jugador);
        void UpdateJugador(JugadorEntity jugador);
        Task DeleteJugadorAsync(int id);
    }
}
