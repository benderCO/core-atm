using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atm;
using Atm.Data;

namespace Atm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmStockController : ControllerBase
    {
        private readonly AtmContext _context;

        public AtmStockController(AtmContext context)
        {
            _context = context;
        }

        // GET: api/AtmStock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtmStock>>> GetAtmStock()
        {
            return await _context.AtmStock.ToListAsync();
        }

        // GET: api/AtmStock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtmStock>> GetAtmStock(Guid id)
        {
            var atmStock = await _context.AtmStock.FindAsync(id);

            if (atmStock == null)
            {
                return NotFound();
            }

            return atmStock;
        }

        // PUT: api/AtmStock/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtmStock(Guid id, AtmStock atmStock)
        {
            if (id != atmStock.id)
            {
                return BadRequest();
            }

            _context.Entry(atmStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtmStockExists(id))
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

        // POST: api/AtmStock
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AtmStock>> PostAtmStock(AtmStock atmStock)
        {
            _context.AtmStock.Add(atmStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtmStock", new { id = atmStock.id }, atmStock);
        }

        // DELETE: api/AtmStock/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AtmStock>> DeleteAtmStock(Guid id)
        {
            var atmStock = await _context.AtmStock.FindAsync(id);
            if (atmStock == null)
            {
                return NotFound();
            }

            _context.AtmStock.Remove(atmStock);
            await _context.SaveChangesAsync();

            return atmStock;
        }

        private bool AtmStockExists(Guid id)
        {
            return _context.AtmStock.Any(e => e.id == id);
        }
    }
}
