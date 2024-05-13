using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using System;
using System.Linq;

namespace FogelFormedlingenAB.Pages
{
	public class EditAdModel : PageModel
	{
		private readonly AppDbContext _database;
		private readonly AccessControl _accessControl;

		public EditAdModel(AppDbContext database, AccessControl accessControl)
		{
			_database = database;
			_accessControl = accessControl;
		}

		[BindProperty]
		public Ad Ad { get; set; }

		public IActionResult OnGet(int? id)
		{
			if (id.HasValue)
			{
				Ad = _database.Ads.FirstOrDefault(ad => ad.ID == id && ad.AccountID == _accessControl.LoggedInAccountID);

				if (Ad == null)
				{
					return NotFound();
				}
			}

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			else
			{
				var existingAd = _database.Ads.FirstOrDefault(ad => ad.ID == Ad.ID && ad.AccountID == _accessControl.LoggedInAccountID);

				if (existingAd == null)
				{
					return NotFound();
				}

				existingAd.Title = Ad.Title;
				existingAd.ImageID = Ad.ImageID;
				existingAd.Category = Ad.Category;
				existingAd.Price = Ad.Price;
				existingAd.Description = Ad.Description;
				existingAd.StartDate = DateTime.Now;

				_database.SaveChanges();

				return RedirectToPage("/Index");
			}
		}
	}
}