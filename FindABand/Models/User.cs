using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindABand.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }

        public string? MainInstrument { get; set; }

        public string? Bio { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public Address? Address { get; set; }

        public ICollection<Band> Bands { get; set; }

        public ICollection<Ad> Ads { get; set; }
    }
}
