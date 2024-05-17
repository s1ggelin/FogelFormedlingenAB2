using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using FogelFormedlingenAB.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FogelFormedlingenAB.Pages
{
	public class IndexModel : PageModel
	{
		private readonly AppDbContext database;

		public IndexModel(AppDbContext database)
		{
			this.database = database;
		}

		public List<Ad> Ads { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }
		public string? SearchString { get; set; }
		
		public List<Category> Categories { get; set; } = new List<Category>();

		public async Task OnGetAsync(int pageNumber = 1, string? searchString = null, int? categoryId = null)
		{
			Ads = await AdServices.GetAds(pageNumber, searchString, categoryId);
			TotalPages = await AdServices.GetTotalPages(searchString, categoryId);
			CurrentPage = pageNumber;
			Categories = await AdServices.GetCategories();

			SearchString = searchString; 
			 // Convert categoryId to string for display in the search form
		}
		
		
	}
}