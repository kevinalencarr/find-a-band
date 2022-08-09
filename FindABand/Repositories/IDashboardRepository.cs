using FindABand.Models;

namespace FindABand.Repositories
{
    public interface IDashboardRepository
    {
        Task<List<Band>> GetAllUserBands();

        Task<List<Ad>> GetAllUserAds();
    }
}
