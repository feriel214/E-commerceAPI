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
    public class UtilisateursController : ControllerBase
    {
        private readonly ECommerceAPIContext _context;

        public UtilisateursController(ECommerceAPIContext context)
        {
            _context = context;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        public IEnumerable<Utilisateur> GetUtilisateurs()
        {
            return _context.Utilisateurs;
        }

        // GET: api/Utilisateurs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUtilisateur([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return Ok(utilisateur);
        }

        // PUT: api/Utilisateurs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateur([FromRoute] Guid id, [FromBody] Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utilisateur.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(utilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurExists(id))
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

        // POST: api/Utilisateurs
        [HttpPost]
        public async Task<IActionResult> PostUtilisateur([FromBody] Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilisateur", new { id = utilisateur.IdUser }, utilisateur);
        }

        // DELETE: api/Utilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateur([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return Ok(utilisateur);
        }

        private bool UtilisateurExists(Guid id)
        {
            return _context.Utilisateurs.Any(e => e.IdUser == id);
        }
    }
}