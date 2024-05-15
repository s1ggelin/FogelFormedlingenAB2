using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using Microsoft.EntityFrameworkCore;

namespace FogelFormedlingenAB.Pages
{
	public class CreateAdModel : PageModel
	{
		private readonly AppDbContext _database;
		private readonly AccessControl _accessControl;
		public List<Category> Categories { get; set; }

		public CreateAdModel(AppDbContext database, AccessControl accessControl)
		{
			_database = database;
			_accessControl = accessControl;
		}

		[BindProperty]
		public string ImageUrl { get; set; }

		[BindProperty]
		public Ad Ad { get; set; }
	

		public IActionResult OnGet()
		{
			Categories = _database.categories.ToList();
			return Page();
		}

		public IActionResult OnPost()
		{
			
			Ad.AccountID = _accessControl.LoggedInAccountID;
			Ad.Account = _database.Accounts.Find(Ad.AccountID);
			Ad.IsActive = true;
			Ad.StartDate = DateTime.Now;

			int selectedCategoryID;
			if (int.TryParse(Request.Form["Ad.CategoryID"], out selectedCategoryID))
			{
				var selectedCategory = _database.categories.Find(selectedCategoryID);
				Ad.Category = selectedCategory;
			}
           
	
            var image = new Image { ImageUrl = ImageUrl };
            Ad.Image = image;

            _database.Ads.Add(Ad);
            _database.Images.Add(image);

            _database.SaveChanges();

            return RedirectToPage("/Index");
           
		}
	}
}