using APIFarm.Model;
using APIFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly FarmDbContext _context;
        public FarmController(FarmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farm>>> GetAll()
        {
            return await _context.Farms.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Farm>> GetById(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
                return NotFound();

            return farm;
        }

        [HttpPost]
        public async Task<ActionResult<Farm>> Create(Farm farm)
        {
            _context.Farms.Add(farm);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = farm.FarmID }, farm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Farm farm)
        {
            if (id != farm.FarmID)
                return BadRequest();

            _context.Entry(farm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Farms.Any(e => e.FarmID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
                return NotFound();

            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
