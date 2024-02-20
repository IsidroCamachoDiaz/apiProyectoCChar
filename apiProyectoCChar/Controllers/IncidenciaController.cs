using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace apiProyectoCChar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciaController : ControllerBase
    {
        private readonly ProyectoTerceraContext _context;

        public IncidenciaController(ProyectoTerceraContext context)
        {
            _context = context;
        }

        // GET: api/Incidencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incidencia>>> GetIncidencias()
        {
          if (_context.Incidencias == null)
          {
              return NotFound();
          }
            return await _context.Incidencias.Include(x=>x.IdUsuarioNavigation).ToListAsync();
        }

        // GET: api/Incidencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incidencia>> GetIncidencia(int id)
        {
          if (_context.Incidencias == null)
          {
              return NotFound();
          }
            var incidencia = await _context.Incidencias.Include(x => x.IdUsuarioNavigation).Include(x => x.IdSolicitudNavigation).FirstOrDefaultAsync(x => x.IdIncidencia == id);

            if (incidencia == null)
            {
                return NotFound();
            }

            return incidencia;
        }

        // PUT: api/Incidencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidencia(int id, Incidencia incidencia)
        {
            if (id != incidencia.IdIncidencia)
            {
                return BadRequest();
            }
            incidencia.IdUsuario = incidencia.IdUsuarioNavigation.IdUsuario;

            _context.Entry(incidencia).State = EntityState.Modified;

            try
            {
                _context.Solicitudes.Update(incidencia.IdSolicitudNavigation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenciaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Incidencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incidencia>> PostIncidencia(Incidencia incidencia)
        {
          if (_context.Incidencias == null)
          {
              return Problem("Entity set 'ProyectoTerceraContext.Incidencias'  is null.");
          }
            _context.Incidencias.Add(incidencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidencia", new { id = incidencia.IdIncidencia }, incidencia);
        }

        // DELETE: api/Incidencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidencia(int id)
        {
            if (_context.Incidencias == null)
            {
                return NotFound();
            }
            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }

            _context.Incidencias.Remove(incidencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidenciaExists(int id)
        {
            return (_context.Incidencias?.Any(e => e.IdIncidencia == id)).GetValueOrDefault();
        }
    }
}
