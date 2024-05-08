using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using System.Linq;

namespace FogelFormedlingenAB.Pages
{
	public class MyAccountPageModel : PageModel
	{
		private readonly AppDbContext _db;
		private readonly AccessControl _accessControl;

		public MyAccountPageModel(AppDbContext db, AccessControl accessControl)
		{
			_db = db;
			_accessControl = accessControl;
		}

		public List<Ad> MyAds { get; set; } = new List<Ad>();
		public List<Ad> AdsILiked { get; set; } = new List<Ad>();

		public void OnGet()
		{
			var accountId = _accessControl.LoggedInAccountID;

			MyAds = _db.Ads.Where(ad => ad.AccountID == accountId).ToList();

			AdsILiked = _db.Ads
				.Where(ad => _db.Favourites.Any(f => f.AccountID == accountId && f.AdID == ad.ID))
				.ToList();
		}

		public IActionResult OnPostAddToFavorites(int adId)
		{
			var accountId = _accessControl.LoggedInAccountID;

		
			var existingFavorite = _db.Favourites.FirstOrDefault(f => f.AccountID == accountId && f.AdID == adId);

			if (existingFavorite == null)
			{
			
				var newFavorite = new Favourite { AccountID = accountId, AdID = adId };
				_db.Favourites.Add(newFavorite);
				_db.SaveChanges();
			}

			return RedirectToPage("/MyAccountPage");
		}

		public IActionResult OnPostRemoveFromFavorites(int adId)
		{
			var accountId = _accessControl.LoggedInAccountID;

	
			var favorite = _db.Favourites.FirstOrDefault(f => f.AccountID == accountId && f.AdID == adId);

			if (favorite != null)
			{
				_db.Favourites.Remove(favorite);
				_db.SaveChanges();
			}

			return RedirectToPage("/MyAccountPage");
		}
        public IActionResult OnPostRemoveAd(int adId)
        {
            var accountId = _accessControl.LoggedInAccountID;

            var adToRemove = _db.Ads.FirstOrDefault(ad => ad.AccountID == accountId && ad.ID == adId);

            if (adToRemove != null)
            {
                _db.Ads.Remove(adToRemove);
                _db.SaveChanges();
            }

            return RedirectToPage("/MyAccountPage");
        }
    }
}
