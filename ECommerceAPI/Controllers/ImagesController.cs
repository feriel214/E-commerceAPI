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
    public class ImagesController : ControllerBase
    {
        private readonly ECommerceAPIContext _context;

        public ImagesController(ECommerceAPIContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public IEnumerable<Image> GetImages()
        {
            return _context.Images;
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage([FromRoute] Guid id, [FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.IdImage)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        [HttpPost]
        public async Task<IActionResult> PostImage([FromBody] Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.IdImage }, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return Ok(image);
        }

        private bool ImageExists(Guid id)
        {
            return _context.Images.Any(e => e.IdImage == id);
        }
    }
}