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
    public class AccesoController : ControllerBase
    {
        private readonly ProyectoTerceraContext _context;

        public AccesoController(ProyectoTerceraContext context)
        {
            _context = context;
        }

        // GET: api/Acceso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acceso>>> GetAccesos()
        {
          if (_context.Accesos == null)
          {
              return NotFound();
          }
            return await _context.Accesos.ToListAsync();
        }

        // GET: api/Acceso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acceso>> GetAcceso(int id)
        {
          if (_context.Accesos == null)
          {
              return NotFound();
          }
            var acceso = await _context.Accesos.FindAsync(id);

            if (acceso == null)
            {
                return NotFound();
            }

            return acceso;
        }

        // PUT: api/Acceso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcceso(int id, Acceso acceso)
        {
            if (id != acceso.IdAcceso)
            {
                return BadRequest();
            }

            _context.Entry(acceso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesoExists(id))
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

        // POST: api/Acceso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Acceso>> PostAcceso(Acceso acceso)
        {
          if (_context.Accesos == null)
          {
              return Problem("Entity set 'ProyectoTerceraContext.Accesos'  is null.");
          }
            _context.Accesos.Add(acceso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcceso", new { id = acceso.IdAcceso }, acceso);
        }

        // DELETE: api/Acceso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcceso(int id)
        {
            if (_context.Accesos == null)
            {
                return NotFound();
            }
            var acceso = await _context.Accesos.FindAsync(id);
            if (acceso == null)
            {
                return NotFound();
            }

            _context.Accesos.Remove(acceso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccesoExists(int id)
        {
            return (_context.Accesos?.Any(e => e.IdAcceso == id)).GetValueOrDefault();
        }
    }
}
