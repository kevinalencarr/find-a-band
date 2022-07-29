using FindABand.Data;
using FindABand.Models;
using FindABand.Repositories;
using FindABand.Services;
using FindABand.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Controllers
{
    public class BandController : Controller
    {
        private readonly IBandRepository _bandRepository;
        private readonly IPhotoService _photoService;

        public BandController(IBandRepository bandRepository, IPhotoService photoService)
        {
            _bandRepository = bandRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> CreateBand(CreateBandViewModel bandViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(bandViewModel.Image);

                var band = new Band
                {
                    Name = bandViewModel.Name,
                    Bio = bandViewModel.Bio,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = bandViewModel.Address.Street,
                        City = bandViewModel.Address.City,
                        State = bandViewModel.Address.State
                    }
                };

                await _bandRepository.CreateBandAsync(band);

                await _bandRepository.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(bandViewModel);
        }

        public async Task<IActionResult> EditBand(int id)
        {
            var band = await _bandRepository.GetBandByIdAsync(id);
            if (band == null)
                return View("Error");

            var bandViewModel = new EditBandViewModel
            {
                Name = band.Name,
                Bio = band.Bio,
                URL = band.Image,
                AddressId = (int)band.AddressId,
                Address = band.Address,
                BandGenre = band.BandGenre
            };

            return View(bandViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditBand(int id, EditBandViewModel bandViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit band");
                return View("Edit", bandViewModel);
            }

            var userBand = await _bandRepository.GetBandByIdAsyncNoTracking(id);

            if (userBand != null)
            {
                try
                {
                    var fi = new FileInfo(userBand.Image);

                    var publicId = Path.GetFileNameWithoutExtension(fi.Name);

                    await _photoService.DeletePhotoAsync(publicId);
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Could not delete photo");
                    return View(bandViewModel);
                }
                
                var photoResult = await _photoService.AddPhotoAsync(bandViewModel.Image);

                var band = new Band
                {
                    Id = id,
                    Name = bandViewModel.Name,
                    Bio = bandViewModel.Bio,
                    Image = photoResult.Url.ToString(),
                    AddressId = bandViewModel.AddressId,
                    Address = bandViewModel.Address
                };

                _bandRepository.UpdateBand(band);

                await _bandRepository.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            else
            {
                return View(bandViewModel);
            }
        }

        public async Task<IActionResult> DeleteBand(int id)
        {
            var bandDetail = await _bandRepository.GetBandByIdAsync(id);

            if (bandDetail == null)
                return View("Error");

            return View(bandDetail);
        }

        [HttpPost, ActionName("DeleteBand")]
        public async Task<IActionResult> Delete(int id)
        {
            var bandDetail = await _bandRepository.GetBandByIdAsync(id);

            if (bandDetail == null)
                return View("Error");

            _bandRepository.DeleteBand(bandDetail);

            await _bandRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
