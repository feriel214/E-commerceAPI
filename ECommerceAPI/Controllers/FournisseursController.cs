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
    public class FournisseursController : ControllerBase
    {
        private readonly ECommerceAPIContext _context;

        public FournisseursController(ECommerceAPIContext context)
        {
            _context = context;
        }

        // GET: api/Fournisseurs
        [HttpGet]
        public IEnumerable<Fournisseur> GetFournisseurs()
        {
            return _context.Fournisseurs;
        }

        // GET: api/Fournisseurs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFournisseur([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fournisseur = await _context.Fournisseurs.FindAsync(id);

            if (fournisseur == null)
            {
                return NotFound();
            }

            return Ok(fournisseur);
        }

        // PUT: api/Fournisseurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFournisseur([FromRoute] Guid id, [FromBody] Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fournisseur.IdFournisseur)
            {
                return BadRequest();
            }

            _context.Entry(fournisseur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FournisseurExists(id))
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

        // POST: api/Fournisseurs
        [HttpPost]
        public async Task<IActionResult> PostFournisseur([FromBody] Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fournisseurs.Add(fournisseur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFournisseur", new { id = fournisseur.IdFournisseur }, fournisseur);
        }

        // DELETE: api/Fournisseurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFournisseur([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fournisseur = await _context.Fournisseurs.FindAsync(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            _context.Fournisseurs.Remove(fournisseur);
            await _context.SaveChangesAsync();

            return Ok(fournisseur);
        }

        private bool FournisseurExists(Guid id)
        {
            return _context.Fournisseurs.Any(e => e.IdFournisseur == id);
        }
    }
}