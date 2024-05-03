using FogelFormedlingenAB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FogelFormedlingenAB.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reported> reports { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
