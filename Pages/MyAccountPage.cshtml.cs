using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using System.Linq;
using FogelFormedlingenAB.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace FogelFormedlingenAB.Pages
{
    public class MyAccountPageModel : PageModel
    {
        private readonly AppDbContext _database;
        private readonly AccessControl _accessControl;

        public MyAccountPageModel(AccessControl accessControl, AppDbContext database)
        {
            _accessControl = accessControl;
            _database = database;
        }

        public List<Ad> MyAds { get; set; } = new List<Ad>();


        /*public List<Ad> AdsILiked { get; set; } = new List<Ad>();*/

        public async Task OnGet()
        {
            var accountId = _accessControl.LoggedInAccountID;

            MyAds = await AdServices.GetAdsByAccountId(accountId); // Filter by account ID


        }
        //-----------------------BELOW IS WORK IN PROGRESS----------------
        /*AdsILiked = _db.Ads
            .Where(ad => _db.Favourites.Any(f => f.AccountID == accountId && f.AdID == ad.ID))
            .ToList();*/


        /*public IActionResult OnPostAddToFavorites(int adId)
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
		}*/
        public async Task<IActionResult> OnPostRemoveAd(int adId)
        {
            var accountId = _accessControl.LoggedInAccountID;
            MyAds = await AdServices.GetAdsByAccountId(accountId);
            var adToRemove = MyAds.FirstOrDefault(ad => ad.AccountID == accountId && ad.ID == adId);

            if (adToRemove == null)
            {
                return RedirectToPage("/MyAccountPage");
            }

            var success = await AdServices.DeleteAd(adId); // bool to check if successful in servicetree continue
            if (!success)
            {
                return RedirectToPage("/MyAccountPage");
            }

            MyAds.Remove(adToRemove); //remove from local list in case

            return RedirectToPage("/MyAccountPage");
        }

        public async Task<IActionResult> OnPostDeleteAccount()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Page("/Index")
            });

            return RedirectToPage("/Index");

        }
    }
}
