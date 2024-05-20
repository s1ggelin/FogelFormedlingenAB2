using FogelFormedlingenAB.Models;
using FogelFormedlingenAB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FogelFormedlingenAB.Pages
{
    
    public class AdPageModel : PageModel
    {
        public Ad Ad { get; set; }
        public List<Category> Categories { get; set; }
        public string CategoryName { get; set; } // To store the category name

        public async Task OnGetAsync(int adId)
        {
            Ad = await AdServices.GetAd(adId);
            Categories = await AdServices.GetCategories();

            if (Ad != null)
            {
                CategoryName = Categories.FirstOrDefault(c => c.ID == Ad.CategoryID).Name; //linq to find category name to print out since the new database structure in ad is different
            }
            else
            {
                RedirectToPage("/NotFound");
            }
        }
    }
}