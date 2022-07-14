using FindABand.Models;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
