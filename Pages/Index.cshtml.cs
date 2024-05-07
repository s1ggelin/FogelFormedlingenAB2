using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using Microsoft.AspNetCore.Mvc;
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

		public void OnGet()
        {
            Ads = database.Ads.ToList();
        }
    }
}