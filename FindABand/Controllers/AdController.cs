using FindABand.Data;
using FindABand.Models;
using FindABand.Repositories;
using FindABand.Services;
using FindABand.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdRepository _adRepository;
        private readonly IPhotoService _photoService;

        public AdController(IAdRepository adRepository, IPhotoService photoService)
        {
            _adRepository = adRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> CreateAd(CreateAdViewModel adViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(adViewModel.Image);

                var ad = new Ad
                {
                    Title = adViewModel.Title,
                    Description = adViewModel.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = adViewModel.Address.Street,
                        City = adViewModel.Address.City,
                        State = adViewModel.Address.State
                    }
                };

                await _adRepository.CreateAdAsync(ad);

                await _adRepository.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(adViewModel);
        }
    }
}
