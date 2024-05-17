using FogelFormedlingenAB.Models;
using FogelFormedlingenAB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FogelFormedlingenAB.Pages
{
	[Route("/ads/{adId}")]
	public class AdPageModel : PageModel
	{
		public Ad Ad { get; set; }

		public async Task OnGetAsync(int adId)
		{
			Ad = await AdServices.GetAd(adId);
		}
	}
}	
