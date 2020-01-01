using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremierLeague.Exceptions;
using PremierLeague.Data.Entities;
using PremierLeague.Data.Repository;
using PremierLeague.Models;

namespace PremierLeague.Services
{
    public class EquiposService : IEquiposService
    {
        private HashSet<string> allowedOrderByValues;
        private IPremierLeagueRepository premierLeagueRepository;
        private readonly IMapper mapper;
        public EquiposService(IPremierLeagueRepository premierLeagueRepository, IMapper mapper)
        {
            this.premierLeagueRepository = premierLeagueRepository;
            this.mapper = mapper;
            allowedOrderByValues = new HashSet<string>() { "nombre", "entrenador", "estadio", "id" };
        }

        public async Task<Equipo> CreateEquipoAsync(Equipo newEquipo)
        {
            var equipoEntity = mapper.Map<EquipoEntity>(newEquipo);
            premierLeagueRepository.CreateEquipo(equipoEntity);
            if (await premierLeagueRepository.SaveChangesAsync())
            {
                return mapper.Map<Equipo>(equipoEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public async Task<bool> DeleteEquipoAsync(int id)
        {
            await validateEquipo(id);
            await premierLeagueRepository.DeleteEquipoAsync(id);
            if (await premierLeagueRepository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<Equipo> GetEquipoAsync(int id, bool showJugadores)
        {
            //validatEquipoId(id);
            //var equipo = premierLeagueRepository.GetEquipo(id, showJugadores);
            //return equipo;
            var equipo = await premierLeagueRepository.GetEquipoAsync(id, showJugadores);

            if (equipo == null)
            {
                throw new NotFoundItemException("equipo not found");
            }

            return mapper.Map<Equipo>(equipo);

        }

        public async Task<IEnumerable<Equipo>> GetEquiposAsync(bool showJugadores, string orderBy)
        {
            var orderByLower = orderBy.ToLower();
            if (!allowedOrderByValues.Contains(orderByLower))
            {
                throw new BadRequestOperationException($"invalid Order By value : {orderBy} the only allowed values are {string.Join(", ", allowedOrderByValues)}");
            }
            var equiposEntities = await premierLeagueRepository.GetEquiposAsync(showJugadores, orderByLower);
            return mapper.Map<IEnumerable<Equipo>>(equiposEntities);
        }

        public async Task<Equipo> UpdateEquipoAsync(int id, Equipo equipo)
        {
            if (id != equipo.id)
            {
                throw new InvalidOperationException("URL id needs to be the same as Equipo id");
            }
            await validateEquipo(id);

            equipo.id = id;
            var equipoEntity = mapper.Map<EquipoEntity>(equipo);
            premierLeagueRepository.UpdateEquipo(equipoEntity);
            if (await premierLeagueRepository.SaveChangesAsync())
            {
                return mapper.Map<Equipo>(equipoEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        private async Task<EquipoEntity> validateEquipo(int id, bool showJugadores = false)
        {
            var equipo = await premierLeagueRepository.GetEquipoAsync(id);
            if (equipo == null)
            {
                throw new NotFoundItemException($"cannot found equipo with id {id}");
            }

            return equipo;
        }
    }
}
