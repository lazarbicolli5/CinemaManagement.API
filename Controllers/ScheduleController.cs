using Microsoft.AspNetCore.Mvc;
using CINEMA.Data;

using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly CinemaDbContext _context;
        public ScheduleController(CinemaDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules() => await _context.Schedules.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Schedule>> AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSchedules), new { id = schedule.Id }, schedule);
        }
    }
}
