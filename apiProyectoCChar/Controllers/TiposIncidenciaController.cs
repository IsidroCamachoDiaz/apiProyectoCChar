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
    public class TiposIncidenciaController : ControllerBase
    {
        private readonly ProyectoTerceraContext _context;

        public TiposIncidenciaController(ProyectoTerceraContext context)
        {
            _context = context;
        }

        // GET: api/TiposIncidencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposIncidencia>>> GetTiposIncidencias()
        {
          if (_context.TiposIncidencias == null)
          {
              return NotFound();
          }
            return await _context.TiposIncidencias.ToListAsync();
        }

        // GET: api/TiposIncidencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposIncidencia>> GetTiposIncidencia(int id)
        {
          if (_context.TiposIncidencias == null)
          {
              return NotFound();
          }
            var tiposIncidencia = await _context.TiposIncidencias.FindAsync(id);

            if (tiposIncidencia == null)
            {
                return NotFound();
            }

            return tiposIncidencia;
        }

        // PUT: api/TiposIncidencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposIncidencia(int id, TiposIncidencia tiposIncidencia)
        {
            if (id != tiposIncidencia.IdTipo)
            {
                return BadRequest();
            }

            _context.Entry(tiposIncidencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposIncidenciaExists(id))
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

        // POST: api/TiposIncidencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposIncidencia>> PostTiposIncidencia(TiposIncidencia tiposIncidencia)
        {
          if (_context.TiposIncidencias == null)
          {
              return Problem("Entity set 'ProyectoTerceraContext.TiposIncidencias'  is null.");
          }
            _context.TiposIncidencias.Add(tiposIncidencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposIncidencia", new { id = tiposIncidencia.IdTipo }, tiposIncidencia);
        }

        // DELETE: api/TiposIncidencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposIncidencia(int id)
        {
            if (_context.TiposIncidencias == null)
            {
                return NotFound();
            }
            var tiposIncidencia = await _context.TiposIncidencias.FindAsync(id);
            if (tiposIncidencia == null)
            {
                return NotFound();
            }

            _context.TiposIncidencias.Remove(tiposIncidencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposIncidenciaExists(int id)
        {
            return (_context.TiposIncidencias?.Any(e => e.IdTipo == id)).GetValueOrDefault();
        }
    }
}
