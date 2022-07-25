using FindABand.Data;
using FindABand.Models;
using FindABand.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Controllers
{
    public class BandController : Controller
    {
        private readonly IBandRepository _bandRepository;

        public BandController(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Band> bands = await _bandRepository.GetAllBandsAsync();
            return View(bands);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Band band = await _bandRepository.GetBandByIdAsync(id);
            return View(band);
        }

        public IActionResult CreateBand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBand(Band band)
        {
            if (!ModelState.IsValid)
            {
                return View(band);
            }

            await _bandRepository.CreateBandAsync(band);
            await _bandRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
