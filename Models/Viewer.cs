using System.ComponentModel.DataAnnotations.Schema;
namespace CinemaAPI.Models

{
    public class Viewer
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; } 
    }
}
