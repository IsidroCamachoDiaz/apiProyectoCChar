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
    public class TrabajoController : ControllerBase
    {
        private readonly ProyectoTerceraContext _context;

        public TrabajoController(ProyectoTerceraContext context)
        {
            _context = context;
        }

        // GET: api/Trabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetTrabajos()
        {
          if (_context.Trabajos == null)
          {
              return NotFound();
          }
            return await _context.Trabajos.Include(x=>x.IdIncidenciaNavigation).Include(x=>x.IdTipoIncidenciaNavigation).ToListAsync();
        }

        // GET: api/Trabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajo>> GetTrabajo(int id)
        {
          if (_context.Trabajos == null)
          {
              return NotFound();
          }
            var trabajo = await _context.Trabajos.Include(x=>x.IdIncidenciaNavigation).Include(x=>x.IdTipoIncidenciaNavigation).FirstOrDefaultAsync(x => x.IdTrabajo == id); ;

            if (trabajo == null)
            {
                return NotFound();
            }

            return trabajo;
        }

        // PUT: api/Trabajo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajo(int id, Trabajo trabajo)
        {
            if (id != trabajo.IdTrabajo)
            {
                return BadRequest();
            }
            trabajo.IdTipoIncidencia = trabajo.IdTipoIncidenciaNavigation.IdTipo;
            trabajo.IdIncidencia = trabajo.IdIncidenciaNavigation.IdIncidencia;

            _context.Entry(trabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajoExists(id))
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

        // POST: api/Trabajo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trabajo>> PostTrabajo(Trabajo trabajo)
        {
          if (_context.Trabajos == null)
          {
              return Problem("Entity set 'ProyectoTerceraContext.Trabajos'  is null.");
          }
            
            _context.Trabajos.Update(trabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajo", new { id = trabajo.IdTrabajo }, trabajo);
        }

        // DELETE: api/Trabajo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajo(int id)
        {
            if (_context.Trabajos == null)
            {
                return NotFound();
            }
            var trabajo = await _context.Trabajos.FindAsync(id);
            if (trabajo == null)
            {
                return NotFound();
            }

            _context.Trabajos.Remove(trabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajoExists(int id)
        {
            return (_context.Trabajos?.Any(e => e.IdTrabajo == id)).GetValueOrDefault();
        }
    }
}
