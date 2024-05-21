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
        private readonly AppDbContext database;
        private readonly AccessControl _accessControl;

        public MyAccountPageModel(AccessControl accessControl, AppDbContext database)
        {
            _accessControl = accessControl;
            this.database = database;
        }

        public List<Ad> MyAds { get; set; } = new List<Ad>();
        public List<Ad> AdsILiked { get; set; } = new List<Ad>(); 
        public double AverageRating { get; set; }

        public async Task OnGet()
        {
            var accountId = _accessControl.LoggedInAccountID;
            var account = database.Accounts.FirstOrDefault(c => c.ID == accountId);
            double averageRating = account.Ratings.Any() ? account.Ratings.Average() : 0;
            AverageRating = averageRating;

            MyAds = await AdServices.GetAdsByAccountId(accountId);// get owned ads
            AdsILiked = await AdServices.GetLikedAds(accountId); // get liked ads
        }

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
        public async Task<IActionResult> OnPostRemoveFromFavourites(int adId)
        {
            var accountId = _accessControl.LoggedInAccountID;
            var success = await AdServices.RemoveFromFavouritesAsync(adId, accountId); //Call the correct method

            if (!success)
            {
                return RedirectToPage("/MyAccountPage");
            }

            AdsILiked = await AdServices.GetLikedAds(accountId); //Refresh the list of liked ads

            return Page(); // Reload the page to reflect changes
        }

        public async Task<IActionResult> OnPostLogOutAccount()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Page("/Index")
            });

            return RedirectToPage("/Index");

        }

    }
}
