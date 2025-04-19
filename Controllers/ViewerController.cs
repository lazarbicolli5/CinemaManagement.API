using Microsoft.AspNetCore.Mvc;
using CINEMA.Data;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewerController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public ViewerController(CinemaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viewer>>> GetViewers()
            => await _context.Viewers.ToListAsync();

       
        [HttpPost]
        public async Task<ActionResult<Viewer>> AddViewer(Viewer viewer)
        {
            _context.Viewers.Add(viewer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetViewers), new { id = viewer.Id }, viewer);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViewer(int id)
        {
            var viewer = await _context.Viewers.FindAsync(id);
            if (viewer == null)
            {
                
                return NotFound();
            }

            _context.Viewers.Remove(viewer);
            await _context.SaveChangesAsync();

            
            return NoContent();
        }
    }
}
