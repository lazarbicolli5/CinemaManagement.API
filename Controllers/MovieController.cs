using Microsoft.AspNetCore.Mvc;
using CINEMA.Data;

using Microsoft.EntityFrameworkCore;
using CinemaAPI.Models;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly CinemaDbContext _context;

        public MovieController(CinemaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
        }
    }
}
