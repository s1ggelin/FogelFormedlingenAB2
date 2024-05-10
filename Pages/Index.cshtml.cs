using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
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
		public string? SearchCategory { get; set; }
		public List<string?> Categories { get; set; } = new List<string?>();


		public void OnGet(int? pageNumber, string searchString, string category)
		{
			if (pageNumber.HasValue)
			{
				CurrentPage = pageNumber.Value;
			}
			const int PageSize = 10;

			IQueryable<Ad> adsQuery = database.Ads;

			if (!string.IsNullOrEmpty(searchString))
			{
				adsQuery = adsQuery.Where(a => a.Title.Contains(searchString));
			}

			if (!string.IsNullOrEmpty(category))
			{
				adsQuery = adsQuery.Where(p => p.Category.Name.Contains(category));
			}

			var totalAds = this.database.Ads.Count();
			TotalPages = (int)Math.Ceiling((double)totalAds / (double)PageSize);

			if (CurrentPage > TotalPages)
			{
				CurrentPage = TotalPages;
			}
			if (CurrentPage < 1)
			{
				CurrentPage = 1;
			}

			Ads = adsQuery
			.Skip((CurrentPage - 1) * PageSize)
			.Take(PageSize)
			.ToList();

			Categories = database.Ads.Select(p => p.Category.Name).ToList();

			SearchString = searchString;
			SearchCategory = category;
		}
		public string GetPictureUrl(int id)
		{
			return Request.Scheme + "://" + Request.Host + "/" + database.Images.Where(i => i.ID == id).Select(i => i.PictureUrl).FirstOrDefault();
        }
	}
}