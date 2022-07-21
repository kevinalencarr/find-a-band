using FindABand.Data;
using FindABand.Models;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Repositories
{
    public class AdRepository : IAdRepository
    {
        private readonly AppDbContext _context;

        public AdRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ad>> GetAllAdsAsync()
        {
            return await _context.Ads.ToListAsync();
        }

        public async Task<Ad?> GetAdByIdAsync(int id)
        {
            return await _context.Ads.Include(i => i.Address).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Ad>> GetAllsAdByCityAsync(string city)
        {
            return await _context.Ads.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task CreateAdAsync(Ad ad)
        {
            if (ad == null)
                throw new ArgumentNullException(nameof(ad));

            await _context.AddAsync(ad);
        }

        // REDO UPDATE METHOD
        public bool UpdateAdAsync(Ad ad)
        {
            var saved = _context.SaveChanges();

            _context.Update(ad);

            return saved > 0 ? true : false;
        }
        //

        public void DeleteAdAsync(Ad ad)
        {
            _context.Remove(ad);
        }
                
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
