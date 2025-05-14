using APICow.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CowController : ControllerBase
    {
        private readonly FarmDbContext _context;
        public CowController(FarmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cow>>> GetAll()
        {
            return await _context.Cows.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Cow>> GetById(int id)
        {
            var cow = await _context.Cows.FindAsync(id);
            if (cow == null)
                return NotFound();

            return cow;
        }

        [HttpPost]
        public async Task<ActionResult<Cow>> Create(Cow cow)
        {
            _context.Cows.Add(cow);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = cow.CowID }, cow);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cow cow)
        {
            if (id != cow.CowID)
                return BadRequest();

            _context.Entry(cow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cows.Any(e => e.CowID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cow = await _context.Cows.FindAsync(id);
            if (cow == null)
                return NotFound();

            _context.Cows.Remove(cow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
