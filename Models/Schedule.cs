
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        //[Column("MovieId")]
        public string MovieName { get; set; }

        //[Column("ShowTime")]
        public DateTime ScheduleTime { get; set; }
    }

}
