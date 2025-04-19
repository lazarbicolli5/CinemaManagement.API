using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaAPI.Models
{
    public class Hall
{
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("SeatCount")]
    public int SeatCount { get; set; }
}
}
