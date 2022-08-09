using FindABand.Data;
using FindABand.Repositories;
using FindABand.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FindABand.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userBands = await _dashboardRepository.GetAllUserBands();
            var userAds = await _dashboardRepository.GetAllUserAds();

            var dashboardViewModel = new DashboardViewModel()
            {
                Ads = userAds,
                Bands = userBands
            };

            return View(dashboardViewModel);
        }
    }
}
