using FindABand.Data;
using FindABand.Models;
using FindABand.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdRepository _adRepository;

        public AdController(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Ad> ads = await _adRepository.GetAllAdsAsync();
            return View(ads);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Ad ad = await _adRepository.GetAdByIdAsync(id);
            return View(ad);
        }

        public IActionResult CreateAd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAd(Ad ad)
        {
            if (!ModelState.IsValid)
            {
                return View(ad);
            }

            await _adRepository.CreateAdAsync(ad);
            await _adRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
