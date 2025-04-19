using Microsoft.AspNetCore.Mvc;
using CINEMA.Data;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public HallController(CinemaDbContext context) => _context = context;

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hall>>> GetHalls()
            => await _context.Halls.ToListAsync();

    
        [HttpPost]
        public async Task<ActionResult<Hall>> AddHall(Hall hall)
        {
            _context.Halls.Add(hall);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHalls), new { id = hall.Id }, hall);
        }

     
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHall(int id, Hall hall)
        {
            if (id != hall.Id)
            {
                return BadRequest();
            }

            _context.Entry(hall).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Halls.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHall(int id)
        {
            var hall = await _context.Halls.FindAsync(id);
            if (hall == null)
            {
                return NotFound();
            }

            _context.Halls.Remove(hall);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
