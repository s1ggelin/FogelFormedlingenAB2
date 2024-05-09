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
		public DbSet<Category> categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
		//Ensure that we only have a account OR ad in out report rather than both
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Reported>()
				.HasCheckConstraint("CK_MyEntity_OneColumnOnly",
					"(AccountID IS NOT NULL AND AdID IS NULL) OR (AccountID IS NULL AND AdID IS NOT NULL)");

			modelBuilder.Entity<Favourite>()
				.HasOne(f => f.Ad)
				.WithMany()
				.HasForeignKey(f => f.AdID)
				.OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

			modelBuilder.Entity<Order>()
				.HasOne(f => f.Ad)
				.WithMany()
				.HasForeignKey(f => f.AdID)
				.OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction
		}
		//Automatically adds Timestamp on Ad record creation
		public override int SaveChanges()
		{
			var entries = ChangeTracker
				.Entries()
				.Where(e => e.Entity is Ad && (e.State == EntityState.Added));

			foreach (var entityEntry in entries)
			{
				((Ad)entityEntry.Entity).StartDate = DateTime.Now;
			}

			return base.SaveChanges();
		}
	}
}
