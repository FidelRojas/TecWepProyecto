using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremierLeague.Data.Entities;
using PremierLeague.Models;
using Microsoft.EntityFrameworkCore;
using PremierLeague.Data;

namespace PremierLeague.Data.Repository
{
    public class PremierLeagueRepository : IPremierLeagueRepository
    {
        private List<Jugador> jugadores = new List<Jugador>();
        private PremierLeagueDbContext premierLeagueDbContext;
        public PremierLeagueRepository(PremierLeagueDbContext premierLeagueDbContext)
        {
            this.premierLeagueDbContext = premierLeagueDbContext;



        }
        public void CreateEquipo(EquipoEntity equipo)
        {
            premierLeagueDbContext.Equipos.Add(equipo);
        }

        public void CreateJugador(JugadorEntity jugador)
        {
            /**var latestJugador = jugadores.OrderByDescendingDescending(b => b.Id).FirstOrDefault();
            var nextJugadorId = latestJugador == null ? 1 : latestJugador.Id + 1;
            jugador.Id = nextJugadorId;
            jugadores.Add(jugador);
            return jugador;*/
            premierLeagueDbContext.Entry(jugador.Equipo).State = EntityState.Unchanged;
            premierLeagueDbContext.Jugadores.Add(jugador);
        }

        public async Task DeleteEquipoAsync(int id)
        {
            var equipoToDelete = await premierLeagueDbContext.Equipos.SingleAsync(a => a.id == id);
            premierLeagueDbContext.Equipos.Remove(equipoToDelete);
        }

        public async Task DeleteJugadorAsync(int id)
        {
            var jugadorToDelete = await premierLeagueDbContext.Jugadores.SingleAsync(a => a.id == id);
            premierLeagueDbContext.Jugadores.Remove(jugadorToDelete);
        }

        public async Task<EquipoEntity> GetEquipoAsync(int id, bool showJugadores)
        {
            //var equipo = equipos.SingleOrDefault(a => a.id == id);
            //if (showJugadores)
            //{
            //    equipo.Jugadores = jugadores.Where(b => b.EquipoId == id);

            //}
            //return equipo;
            IQueryable<EquipoEntity> query = premierLeagueDbContext.Equipos;

            if (showJugadores)
            {
                query = query.Include(a => a.Jugadores);
            }
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(a => a.id == id);
        }

        public async Task<IEnumerable<EquipoEntity>> GetEquiposAsync(bool showJugadores, string orderBy)
        {
            IQueryable<EquipoEntity> query = premierLeagueDbContext.Equipos;
            if (showJugadores)
            {
                query = query.Include(a => a.Jugadores);
            }

            switch (orderBy)
            {
                case "nombre":
                    query = query.OrderByDescending(a => a.nombre);
                    break;
                case "fundacion":
                    query = query.OrderByDescending(a => a.fundacion);
                    break;
                case "entrenador":
                    query = query.OrderByDescending(a => a.entrenador);
                    break;
                default:
                    query = query.OrderByDescending(a => a.id);
                    break;
            }
            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public Task<JugadorEntity> GetJugadorAsync(int id, bool showEquipo)
        {
            IQueryable<JugadorEntity> query = premierLeagueDbContext.Jugadores;
            query = query.AsNoTracking();
            if (showEquipo)
            {
                query = query.Include(b => b.Equipo);
            }
            query = query.AsNoTracking();
            return query.SingleAsync(b => b.id == id);
        }

        public IEnumerable<Jugador> GetJugadores()
        {
            return jugadores;
        }

        public async Task<IEnumerable<JugadorEntity>> GetJugadoresAsync(int equipoId, string orderBy = "id")
        {
            IQueryable<JugadorEntity> query = premierLeagueDbContext.Jugadores;
            //if (showJugadores)
            //{
            //    query = query.Include(a => a.Jugadores);
            //}

            switch (orderBy)
            {
                case "goles":
                    query = query.OrderByDescending(a => a.goles);
                    break;
                case "nombre":
                    query = query.OrderByDescending(a => a.nombre);
                    break;
                case "altura":
                    query = query.OrderByDescending(a => a.altura);
                    break;
                case "numero":
                    query = query.OrderByDescending(a => a.numero);
                    break;
                default:
                    query = query.OrderByDescending(a => a.id);
                    break;
            }
            query = query.AsNoTracking().Where(b => b.Equipo.id == equipoId);
            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<JugadorEntity>> GetTop(string orderBy = "goles")

        {
            IQueryable<JugadorEntity> query = premierLeagueDbContext.Jugadores;
            switch (orderBy)
            {
                case "goles":
                    query = query.OrderByDescending(a => a.goles);
                    break;
                case "nombre":
                    query = query.OrderByDescending(a => a.nombre);
                    break;
                case "altura":
                    query = query.OrderByDescending(a => a.altura);
                    break;
                case "numero":
                    query = query.OrderByDescending(a => a.numero);
                    break;
                default:
                    query = query.OrderByDescending(a => a.id);
                    break;
            }

            return await query.ToArrayAsync();

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await premierLeagueDbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateEquipo(EquipoEntity equipo)
        {
            /*var equipoToUpdate = libraryDBContext.Equipos.Single(a => a.Id == equipo.Id);
            equipoToUpdate.LastName = equipo.LastName;
            equipoToUpdate.Name = equipo.Name;
            equipoToUpdate.Nationallity = equipo.Nationallity;
            equipoToUpdate.Age = equipo.Age;*/

            premierLeagueDbContext.Equipos.Update(equipo);
        }

        public void UpdateJugador(JugadorEntity jugador)
        {
            /*var jugadorToUpdate = premierLeagueDbContext.Jugadores.SingleOrDefault(b => b.Id == jugador.Id);
            if (jugador.Pages != 0)
            {
                jugadorToUpdate.Pages = jugador.Pages
            }*/

            premierLeagueDbContext.Entry(jugador.Equipo).State = EntityState.Unchanged;
            premierLeagueDbContext.Jugadores.Update(jugador);
        }
    }
}
