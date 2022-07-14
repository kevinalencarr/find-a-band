using FindABand.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindABand.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Bio { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address? Address { get; set; }

        public BandGenre BandGenre { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}