using FindABand.Data;
using FindABand.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindABand.Controllers
{
    public class AdController : Controller
    {
        private readonly AppDbContext _context;

        public AdController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Ad> ads = _context.Ads.ToList();
            return View(ads);
        }
    }
}
