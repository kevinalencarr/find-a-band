using FindABand.Data;
using FindABand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Controllers
{
    public class BandController : Controller
    {
        private readonly AppDbContext _context;

        public BandController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Band> bands = _context.Bands.ToList();
            return View(bands);
        }

        public IActionResult Detail(int id)
        {
            Band band = _context.Bands.Include(a => a.Address).FirstOrDefault(b => b.Id == id);
            return View(band);
        }
    }
}
