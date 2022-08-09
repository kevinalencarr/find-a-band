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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdController(IAdRepository adRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _adRepository = adRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
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
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createAdViewModel = new CreateAdViewModel { UserId = currentUserId };

            return View(createAdViewModel);
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
                    UserId = adViewModel.UserId,
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

        public async Task<IActionResult> EditAd(int id)
        {
            var ad = await _adRepository.GetAdByIdAsync(id);
            if (ad == null)
                return View("Error");

            var adViewModel = new EditAdViewModel
            {
                Title = ad.Title,
                Description = ad.Description,
                URL = ad.Image,
                AddressId = ad.AddressId,
                Address = ad.Address,
                AdCategory = ad.AdCategory
            };

            return View(adViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAd(int id, EditAdViewModel adViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit ad");
                return View("Edit", adViewModel);
            }

            var userAd = await _adRepository.GetAdByIdAsyncNoTracking(id);

            if (userAd != null)
            {
                try
                {
                    var fi = new FileInfo(userAd.Image);

                    var publicId = Path.GetFileNameWithoutExtension(fi.Name);

                    await _photoService.DeletePhotoAsync(publicId);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Could not delete photo");
                    return View(adViewModel);
                }

                var photoResult = await _photoService.AddPhotoAsync(adViewModel.Image);

                var ad = new Ad
                {
                    Id = id,
                    Title = adViewModel.Title,
                    Description = adViewModel.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = adViewModel.AddressId,
                    Address = adViewModel.Address
                };

                _adRepository.UpdateAd(ad);

                await _adRepository.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            else
            {
                return View(adViewModel);
            }
        }

        public async Task<IActionResult> DeleteAd(int id)
        {
            var adDetail = await _adRepository.GetAdByIdAsync(id);

            if (adDetail == null)
                return View("Error");

            return View(adDetail);
        }

        [HttpPost, ActionName("DeleteAd")]
        public async Task<IActionResult> Delete(int id)
        {
            var adDetail = await _adRepository.GetAdByIdAsync(id);

            if (adDetail == null)
                return View("Error");

            _adRepository.DeleteAd(adDetail);

            await _adRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
