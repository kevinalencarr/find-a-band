using System.ComponentModel.DataAnnotations;

namespace FindABand.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? MainInstrument { get; set; }

        public string? Bio { get; set; }

        public ICollection<Band> Bands { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}
