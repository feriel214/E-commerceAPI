using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Models;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillesController : ControllerBase
    {
        private readonly ECommerceAPIContext _context;

        public VillesController(ECommerceAPIContext context)
        {
            _context = context;
        }

        // GET: api/Villes
        [HttpGet]
        public IEnumerable<Ville> GetVille()
        {
            return _context.Ville;
        }

        // GET: api/Villes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVille([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ville = await _context.Ville.FindAsync(id);

            if (ville == null)
            {
                return NotFound();
            }

            return Ok(ville);
        }

        // PUT: api/Villes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVille([FromRoute] Guid id, [FromBody] Ville ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ville.IdVille)
            {
                return BadRequest();
            }

            _context.Entry(ville).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VilleExists(id))
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

        // POST: api/Villes
        [HttpPost]
        public async Task<IActionResult> PostVille([FromBody] Ville ville)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ville.Add(ville);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVille", new { id = ville.IdVille }, ville);
        }

        // DELETE: api/Villes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVille([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ville = await _context.Ville.FindAsync(id);
            if (ville == null)
            {
                return NotFound();
            }

            _context.Ville.Remove(ville);
            await _context.SaveChangesAsync();

            return Ok(ville);
        }

        private bool VilleExists(Guid id)
        {
            return _context.Ville.Any(e => e.IdVille == id);
        }
    }
}