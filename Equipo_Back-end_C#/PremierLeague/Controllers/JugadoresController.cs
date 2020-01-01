using PremierLeague.Exceptions;
using PremierLeague.Models;
using PremierLeague.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Controllers
{
    [Route("api/equipos/{equipoId:int}/jugadores")]
    public class JugadoresController : ControllerBase
    {
        private IJugadoresService jugadoresService;
        public JugadoresController(IJugadoresService jugadoresService)
        {
            this.jugadoresService = jugadoresService;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Jugador>>> getJugadores(int equipoId)
        {
            //try
            //{
            //    var jugadores = jugadoresService.GetJugadores(equipoId);
            //    return Ok(jugadores);
            //}
            //catch (NotFoundItemException ex)
            //{
            //    return NotFound(ex.Message);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            try
            {
                return Ok(await jugadoresService.GetJugadores(equipoId));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jugador>> getJugador(int equipoId, int id)
        {
            try
            {
                var jugadores = await jugadoresService.GetJugadorAsync(equipoId, id);
                return Ok(jugadores);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost()]
        public async Task<ActionResult<Jugador>> PostJugador(int equipoId, [FromBody] Jugador jugador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var jugadorCreated = await jugadoresService.AddJugadorAsync(equipoId, jugador);
                return Created($"/api/equipos/{equipoId}/jugadores/{jugador.id}", jugadorCreated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Jugador>> PutJugador(int equipoId, int id, [FromBody] Jugador jugador)
        {
            try
            {
                return Ok(await jugadoresService.EditJugadorAsync(equipoId, id, jugador));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<bool>> DeleteJugador(int equipoId, int id)
        {
            try
            {
                return Ok(await this.jugadoresService.RemoveJugador(equipoId,id));
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
