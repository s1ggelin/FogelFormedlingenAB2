using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;

namespace FogelFormedlingenAB.Pages
{
	public class CreateAdModel : PageModel
	{
		private readonly AppDbContext _database;
		private readonly AccessControl _accessControl;

		public CreateAdModel(AppDbContext database, AccessControl accessControl)
		{
			this._database = database;
			_accessControl = accessControl;
		}

		[BindProperty]
		public Ad Ad { get; set; }
		public IActionResult OnGet()
		{
			return Page();
		}
		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			Ad.AccountID = _accessControl.LoggedInAccountID;
			Ad.IsActive = true;
			
			Ad.StartDate = DateTime.Now;
			

			// Add the Ad object to the database
			_database.Ads.Add(Ad);
			_database.SaveChanges();

			return RedirectToPage("/Index");
		}
	}
}
