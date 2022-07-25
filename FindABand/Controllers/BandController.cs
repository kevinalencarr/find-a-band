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
    }
}
