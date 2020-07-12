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
    public class EtatCmdsController : ControllerBase
    {
        private readonly ECommerceAPIContext _context;

        public EtatCmdsController(ECommerceAPIContext context)
        {
            _context = context;
        }

        // GET: api/EtatCmds
        [HttpGet]
        public IEnumerable<EtatCmd> GetEtatCmds()
        {
            return _context.EtatCmds;
        }

        // GET: api/EtatCmds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEtatCmd([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var etatCmd = await _context.EtatCmds.FindAsync(id);

            if (etatCmd == null)
            {
                return NotFound();
            }

            return Ok(etatCmd);
        }

        // PUT: api/EtatCmds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtatCmd([FromRoute] Guid id, [FromBody] EtatCmd etatCmd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etatCmd.IdEtatCmd)
            {
                return BadRequest();
            }

            _context.Entry(etatCmd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtatCmdExists(id))
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

        // POST: api/EtatCmds
        [HttpPost]
        public async Task<IActionResult> PostEtatCmd([FromBody] EtatCmd etatCmd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EtatCmds.Add(etatCmd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtatCmd", new { id = etatCmd.IdEtatCmd }, etatCmd);
        }

        // DELETE: api/EtatCmds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtatCmd([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var etatCmd = await _context.EtatCmds.FindAsync(id);
            if (etatCmd == null)
            {
                return NotFound();
            }

            _context.EtatCmds.Remove(etatCmd);
            await _context.SaveChangesAsync();

            return Ok(etatCmd);
        }

        private bool EtatCmdExists(Guid id)
        {
            return _context.EtatCmds.Any(e => e.IdEtatCmd == id);
        }
    }
}