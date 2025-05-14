using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CowController : ControllerBase
    {
        private readonly FarmDbContext _context;
        public FarmingController(FarmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farming>>> GetAll()
        {
            return await _context.Farm.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Farming>> GetById(int id)
        {
            var farming = await _context.Farm.FindAsync(id);
            if (farming == null)
                return NotFound();

            return farming;
        }

        [HttpPost]
        public async Task<ActionResult<Farming>> Create(Farming farming)
        {
            _context.Farm.Add(farming);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = farming.FarmingID }, Farming);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Farming farming)
        {
            if (id != farming.FarmingID)
                return BadRequest();

            _context.Entry(farming).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Farm.Any(e => e.FarmingID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var farming = await _context.Farm.FindAsync(id);
            if (farming == null)
                return NotFound();

            _context.Farm.Remove(farming);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
