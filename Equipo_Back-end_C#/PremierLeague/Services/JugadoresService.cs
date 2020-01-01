using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremierLeague.Data.Entities;
using PremierLeague.Data.Repository;
using PremierLeague.Exceptions;
using PremierLeague.Models;

namespace PremierLeague.Services
{
    public class JugadoresService : IJugadoresService
    {
        private HashSet<string> allowedOrderByValues;
        private IPremierLeagueRepository premierLeagueRepository;
        private readonly IMapper mapper;
        public JugadoresService(IPremierLeagueRepository premierLeagueRepository, IMapper mapper)
        {
            this.premierLeagueRepository = premierLeagueRepository;
            this.mapper = mapper;
            allowedOrderByValues = new HashSet<string>() { "nombre", "numero", "pais", "id" };

        }

        public async Task<Jugador> AddJugadorAsync(int equipoId, Jugador jugador)
        {
            if (jugador.equipoId != null && equipoId != jugador.equipoId)
            {
                throw new BadRequestOperationException("URL equipo id and Jugador.EquipoId should be equal");
            }
            jugador.equipoId = equipoId;
            var equipoEntity = await validatEquipoId(equipoId);
            var jugadorEntity = mapper.Map<JugadorEntity>(jugador);

            premierLeagueRepository.CreateJugador(jugadorEntity);
            if (await premierLeagueRepository.SaveChangesAsync())
            {
                return mapper.Map<Jugador>(jugadorEntity);
            }
            throw new Exception("There were an error with the DB");
        }

        public async Task<Jugador> EditJugadorAsync(int equipoId, int id, Jugador jugador)
        {

            if (jugador.id != null && jugador.id != id)
            {
                throw new InvalidOperationException("jugador URL id and jugador body id should be the same");
            }

            await ValidateEquipoAndJugador(equipoId, id);

            jugador.equipoId = equipoId;
            var jugadorEntity = mapper.Map<JugadorEntity>(jugador);
            premierLeagueRepository.UpdateJugador(jugadorEntity);
            if (await premierLeagueRepository.SaveChangesAsync())
            {
                return mapper.Map<Jugador>(jugadorEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public async Task<Jugador> GetJugadorAsync(int equipoId, int id)
        {
            await ValidateEquipoAndJugador(equipoId, id);
            var jugadorEntity = await premierLeagueRepository.GetJugadorAsync(id);
            return mapper.Map<Jugador>(jugadorEntity);
        }

        public async Task<IEnumerable<Jugador>> GetJugadores(int equipoId)
        {
            string orderBy = "id";
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new BadRequestOperationException($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }
            var jugadoresEntities = await premierLeagueRepository.GetJugadoresAsync(equipoId, orderByLower);

            return mapper.Map<IEnumerable<Jugador>>(jugadoresEntities);
        }

        public async Task<bool> RemoveJugador(int equipoId, int id)
        {
            await ValidateEquipoAndJugador(equipoId,id);
            await premierLeagueRepository.DeleteJugadorAsync(id);
            if (await premierLeagueRepository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        private async Task<EquipoEntity> validatEquipoId(int id, bool showJugadores = false)
        {
            var equipo = await premierLeagueRepository.GetEquipoAsync(id);
            if (equipo == null)
            {
                throw new NotFoundItemException($"cannot found equipo with id {id}");
            }

            return equipo;
        }

        private async Task<bool> ValidateEquipoAndJugador(int equipoId, int jugadorId)
        {

            var equipo = await premierLeagueRepository.GetEquipoAsync(equipoId);
            if (equipo == null)
            {
                throw new NotFoundItemException($"cannot found equipo with id {equipoId}");
            }

            var jugador = await premierLeagueRepository.GetJugadorAsync(jugadorId, true);
            if (jugador == null || jugador.Equipo.id != equipoId)
            {
                throw new NotFoundItemException($"Jugador not found with id {jugadorId} for equipo {equipoId}");
            }

            return true;
        }
    }
}
