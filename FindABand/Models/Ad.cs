using FindABand.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindABand.Models
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address? Address { get; set; }

        public AdCategory AdCategory { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
