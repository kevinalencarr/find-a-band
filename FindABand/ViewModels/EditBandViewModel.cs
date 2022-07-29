using FindABand.Data.Enums;
using FindABand.Models;

namespace FindABand.ViewModels
{
    public class EditBandViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public IFormFile Image { get; set; }

        public string? URL { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public BandGenre BandGenre { get; set; }
    }
}
