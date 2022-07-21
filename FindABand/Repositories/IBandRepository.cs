using FindABand.Models;

namespace FindABand.Repositories
{
    public interface IBandRepository
    {
        Task<IEnumerable<Band>> GetAllBandsAsync();

        Task<Band?> GetBandByIdAsync(int id);

        Task<IEnumerable<Band>> GetBandByCityAsync(string city);

        Task CreateBandAsync(Band band);

        bool UpdateBand(Band band);

        void DeleteBandAsync(Band band);

        Task SaveChangesAsync();
    }
}
