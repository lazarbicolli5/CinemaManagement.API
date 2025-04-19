using Microsoft.EntityFrameworkCore;
using CinemaAPI.Models;

namespace CINEMA.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Viewer> Viewers { get; set; }
    }
}

