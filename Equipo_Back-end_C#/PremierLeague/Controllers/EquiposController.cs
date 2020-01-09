using System;
using PremierLeague.Exceptions;
using PremierLeague.Models;
using PremierLeague.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.Controllers
{
    [Route("api/[controller]")]

    public class EquiposController : Controller
    {
        private IEquiposService equiposService;

        public EquiposController(IEquiposService equiposService)
        {
            this.equiposService = equiposService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipos(bool showJugadores = true, string orderBy = "id")
        {
            try
            {
                return Ok(await equiposService.GetEquiposAsync(showJugadores, orderBy));
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

        [HttpGet("top")]
        public async Task<ActionResult<Equipo>> GetTop()
        {
            try
            {
                var equipo = await equiposService.GetTopAsync();
                return Ok(equipo);

            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> GetEquipoAsync(int id, bool showJugadores = true)
        {
            try
            {
                var equipo = await equiposService.GetEquipoAsync(id, showJugadores);
                return Ok(equipo);

            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }

        }
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo([FromBody] Equipo equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEquipo = await equiposService.CreateEquipoAsync(equipo);
            return Created($"/api/equipos/{createdEquipo.id}", createdEquipo);
        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<bool>> DeleteEquipo(int id)
        {
            try
            {
                return Ok(await this.equiposService.DeleteEquipoAsync(id));
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
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Equipo>> PutEquipo(int id, [FromBody]Equipo equipo)
        {
           

            try
            {
                return Ok(await equiposService.UpdateEquipoAsync(id, equipo));

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
    }
}