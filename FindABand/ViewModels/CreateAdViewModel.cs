using FindABand.Data.Enums;
using FindABand.Models;

namespace FindABand.ViewModels
{
    public class CreateAdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public AdCategory AdCategory{ get; set; }

        public Address Address { get; set; }
    }
}
