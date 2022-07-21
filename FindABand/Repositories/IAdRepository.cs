using FindABand.Models;

namespace FindABand.Repositories
{
    public interface IAdRepository
    {
        Task SaveChangesAsync();

        Task<IEnumerable<Ad>> GetAllAdsAsync();

        Task<Ad?> GetAdByIdAsync(int id);

        Task<IEnumerable<Ad>> GetAllsAdByCityAsync(string city);

        Task CreateAdAsync(Ad ad);

        bool UpdateAdAsync(Ad ad);

        void DeleteAdAsync(Ad ad);
    }
}
