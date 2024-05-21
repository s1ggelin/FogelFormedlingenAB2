
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using FogelFormedlingenAB.Models;
using FogelFormedlingenAB.Services;
using FogelFormedlingenAB.Data;
using Microsoft.EntityFrameworkCore.Update;

namespace FogelFormedlingenAB.Pages
{
    public class AdPageModel : PageModel
    {
        private readonly AppDbContext database;
        private readonly AccessControl _accessControl; // Inject AccessControl service

        public AdPageModel( AccessControl accessControl, AppDbContext database)
        {
            _accessControl = accessControl;
            this.database = database;
        }
        public Ad Ad { get; set; }
        public Favourite Favourite { get; set; }
        public List<Category> Categories { get; set; }
        public string CategoryName { get; set; } // To store the category name

        public bool RatingFormVisible { get; set; } 
        public int Rating { get; set; }
        public List<int> Ratings { get; set; }
        public Account SellerAccount { get; set; }

        public async Task OnGetAsync(int adId)
        {
            Ad = await AdServices.GetAd(adId);
            Categories = await AdServices.GetCategories();
            SellerAccount = database.Accounts.First(c => c.ID == Ad.AccountID);
            

            if (Ad != null)
            {
                CategoryName = Categories.FirstOrDefault(c => c.ID == Ad.CategoryID)?.Name; // Null propagation operator used here
            }
            else
            {
                RedirectToPage("/NotFound");
            }
        }
        public async Task<IActionResult> OnPostAddToFavourites(int adId)
        {
            var accountId = _accessControl.LoggedInAccountID;
            var newFavorite = new Favourite { AccountID = accountId, AdID = adId };

            if (await AdServices.AddToFavouritesAsync(newFavorite)) 
            {
                TempData["SuccessMessage"] = "Ad added to your favourites!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add ad to favourites. Please try again later.";
            }

            return RedirectToPage("/AdPage", new { adid = adId });
        }

        public async Task<IActionResult> OnPostAsync(int adId, int rating)
        {
            

            try
            {
                Ad = await AdServices.GetAd(adId);
                
                if (Ad == null)
                {
                    return RedirectToPage("/NotFound");
                }

                
                
                if (SellerAccount != null)
                {
                    SellerAccount.Ratings.Add(rating);
                    database.SaveChanges();
                }
                
                // Mark the ad as inactive
                Ad.IsActive = false;

                // Create a new order
                var order = new Order
                {
                    AccountId = _accessControl.LoggedInAccountID, // Set AccountId to the same as logged-in user's ID
                    AdID = adId,
                    Ad = Ad, // Set the Ad property of the Order to the fetched Ad object
                    BoughtDate = DateTime.Now
                };
                
                // Save changes to the database
                await AdServices.UpdateAd(adId, Ad);
                await AdServices.CreateOrder(order);

                // Redirect to a confirmation page or display a success message
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                // Log the error
                return RedirectToPage("/Error");
            }
        }

        public IActionResult OnPostToggleRatingForm()
        {
            RatingFormVisible = !RatingFormVisible;
            return Page();
        }

    }
}
