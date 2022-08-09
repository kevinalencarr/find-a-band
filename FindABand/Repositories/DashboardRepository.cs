using FindABand.Data;
using FindABand.Models;

namespace FindABand.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Band>> GetAllUserBands()
        {
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userBands = _context.Bands.Where(b => b.User.Id == currentUser);

            return userBands.ToList();
        }

        public async Task<List<Ad>> GetAllUserAds()
        {
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userAds = _context.Ads.Where(a => a.User.Id == currentUser);

            return userAds.ToList();
        }
    }
}
