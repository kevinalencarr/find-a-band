using FindABand.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindABand.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
