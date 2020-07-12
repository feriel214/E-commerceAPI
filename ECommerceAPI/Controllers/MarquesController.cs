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
    public class MarquesController : ControllerBase
    {
        private readonly ECommerceAPIContext _context;

        public MarquesController(ECommerceAPIContext context)
        {
            _context = context;
        }

        // GET: api/Marques
        [HttpGet]
        public IEnumerable<Marque> GetMarques()
        {
            return _context.Marques;
        }

        // GET: api/Marques/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarque([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marque = await _context.Marques.FindAsync(id);

            if (marque == null)
            {
                return NotFound();
            }

            return Ok(marque);
        }

        // PUT: api/Marques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarque([FromRoute] Guid id, [FromBody] Marque marque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marque.IdMarque)
            {
                return BadRequest();
            }

            _context.Entry(marque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarqueExists(id))
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

        // POST: api/Marques
        [HttpPost]
        public async Task<IActionResult> PostMarque([FromBody] Marque marque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Marques.Add(marque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarque", new { id = marque.IdMarque }, marque);
        }

        // DELETE: api/Marques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarque([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marque = await _context.Marques.FindAsync(id);
            if (marque == null)
            {
                return NotFound();
            }

            _context.Marques.Remove(marque);
            await _context.SaveChangesAsync();

            return Ok(marque);
        }

        private bool MarqueExists(Guid id)
        {
            return _context.Marques.Any(e => e.IdMarque == id);
        }
    }
}