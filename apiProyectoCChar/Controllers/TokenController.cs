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
    public class TokenController : ControllerBase
    {
        private readonly ProyectoTerceraContext _context;

        public TokenController(ProyectoTerceraContext context)
        {
            _context = context;
        }

        // GET: api/Token
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Token>>> GetTokens()
        {
          if (_context.Tokens == null)
          {
              return NotFound();
          }
            return await _context.Tokens.ToListAsync();
        }

        // GET: api/Token/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Token>> GetToken(int id)
        {
          if (_context.Tokens == null)
          {
              return NotFound();
          }
            var token = await _context.Tokens.FindAsync(id);

            if (token == null)
            {
                return NotFound();
            }

            return token;
        }

        // GET: api/Token/token/token
        [HttpGet("token/{token}")]
        public async Task<ActionResult<Token>> GetTokenByToken(string token)
        {
            if (_context.Tokens == null)
            {
                return NotFound();
            }
            var tokenO = await _context.Tokens.FirstOrDefaultAsync(u => u.Token1 == token);

            if (tokenO == null)
            {
                return NotFound();
            }

            return tokenO;
        }

        // PUT: api/Token/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToken(int id, Token token)
        {
            if (id != token.IdToken)
            {
                return BadRequest();
            }

            _context.Entry(token).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TokenExists(id))
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

        // POST: api/Token
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Token>> PostToken(Token token)
        {
          if (_context.Tokens == null)
          {
              return Problem("Entity set 'ProyectoTerceraContext.Tokens'  is null.");
          }
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToken", new { id = token.IdToken }, token);
        }

        // DELETE: api/Token/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToken(int id)
        {
            if (_context.Tokens == null)
            {
                return NotFound();
            }
            var token = await _context.Tokens.FindAsync(id);
            if (token == null)
            {
                return NotFound();
            }

            _context.Tokens.Remove(token);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TokenExists(int id)
        {
            return (_context.Tokens?.Any(e => e.IdToken == id)).GetValueOrDefault();
        }
    }
}
