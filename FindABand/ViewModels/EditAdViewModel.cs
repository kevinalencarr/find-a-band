using FindABand.Data.Enums;
using FindABand.Models;

namespace FindABand.ViewModels
{
    public class EditAdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public string? URL { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public AdCategory AdCategory { get; set; }
    }
}
