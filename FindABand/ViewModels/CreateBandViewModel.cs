using FindABand.Data.Enums;
using FindABand.Models;

namespace FindABand.ViewModels
{
    public class CreateBandViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public IFormFile Image { get; set; }

        public BandGenre BandGenre { get; set; }

        public Address Address { get; set; }

        public string UserId { get; set; }
    }
}
