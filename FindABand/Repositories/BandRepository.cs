using FindABand.Data;
using FindABand.Models;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Repositories
{
    public class BandRepository : IBandRepository
    {
        private readonly AppDbContext _context;

        public BandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Band>> GetAllBandsAsync()
        {
            return await _context.Bands.ToListAsync();
        }

        public async Task<Band?> GetBandByIdAsync(int id)
        {
            return await _context.Bands.Include(i => i.Address).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Band>> GetBandByCityAsync(string city)
        {
            return await _context.Bands.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task CreateBandAsync(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            await _context.AddAsync(band);
        }

        // REDO UPDATE METHOD
        public bool UpdateBand(Band band)
        {
            var saved = _context.SaveChanges();

            _context.Update(band);

            return saved > 0 ? true : false;
        }
        //

        public void DeleteBandAsync(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Remove(band);
        }
                
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
