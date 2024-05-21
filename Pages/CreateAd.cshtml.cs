using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FogelFormedlingenAB.Services;
using FogelFormedlingenAB.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using FogelFormedlingenAB.Data;


namespace FogelFormedlingenAB.Pages

{
    public class CreateAdModel : PageModel

    {

        private readonly AppDbContext _database;
        private readonly AccessControl _accessControl;
        public List<Category> Categories { get; set; }

        public CreateAdModel(AccessControl accessControl)
        { 
            _accessControl = accessControl;
        }

        [BindProperty]
        public string ImageUrl { get; set; }
        [BindProperty]
        public Ad Ad { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await AdServices.GetCategories();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()

        {
            Categories = await AdServices.GetCategories();
            Ad.AccountID = _accessControl.LoggedInAccountID; //Set the AccountID directly on the Ad object.
            Ad.IsActive = true;
            Ad.StartDate = DateTime.Now;


            int selectedCategoryID;

            if (int.TryParse(Request.Form["Ad.CategoryID"], out selectedCategoryID))

            {
                var selectedCategory = Categories.FirstOrDefault(c => c.ID == selectedCategoryID);
                if (selectedCategory != null)
                {
                    Ad.CategoryID = selectedCategory.ID;
                }
            }

            Ad.ImageUrl = ImageUrl; // Set ImageUrl before creating the ad

            var success = await AdServices.CreateAd(Ad);

            if (!success)

            {
                ModelState.AddModelError("", "There was an error creating the ad. Please try again.");
                Categories = await AdServices.GetCategories();
                return Page();
            }

            return RedirectToPage("/Index");

        }

    }

}