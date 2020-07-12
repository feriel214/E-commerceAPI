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
    public class FacturesController : ControllerBase
    {
        private readonly ECommerceAPIContext _context;

        public FacturesController(ECommerceAPIContext context)
        {
            _context = context;
        }

        // GET: api/Factures
        [HttpGet]
        public IEnumerable<Facture> GetFactures()
        {
            return _context.Factures;
        }

        // GET: api/Factures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacture([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facture = await _context.Factures.FindAsync(id);

            if (facture == null)
            {
                return NotFound();
            }

            return Ok(facture);
        }

        // PUT: api/Factures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacture([FromRoute] Guid id, [FromBody] Facture facture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facture.IdFacture)
            {
                return BadRequest();
            }

            _context.Entry(facture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactureExists(id))
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

        // POST: api/Factures
        [HttpPost]
        public async Task<IActionResult> PostFacture([FromBody] Facture facture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Factures.Add(facture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacture", new { id = facture.IdFacture }, facture);
        }

        // DELETE: api/Factures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacture([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facture = await _context.Factures.FindAsync(id);
            if (facture == null)
            {
                return NotFound();
            }

            _context.Factures.Remove(facture);
            await _context.SaveChangesAsync();

            return Ok(facture);
        }

        private bool FactureExists(Guid id)
        {
            return _context.Factures.Any(e => e.IdFacture == id);
        }
    }
}