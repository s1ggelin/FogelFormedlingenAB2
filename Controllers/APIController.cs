using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FogelFormedlingenAB.Controllers
{
    [Route("/api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly AppDbContext database;
		private readonly ILogger<APIController> _logger;


		public APIController(AppDbContext database, ILogger<APIController> logger)
        {
            this.database = database;
            _logger = logger;
        }
        [HttpGet("/ads")]
        [AllowAnonymous]
		public ActionResult<List<Ad>> GetAds(string? title = null, int? categoryId = null, int pageNumber = 1, int pageSize = 10)
		{
			try
			{
				var query = database.Ads.AsQueryable();

				if (!string.IsNullOrEmpty(title))
				{
					query = query.Where(a => a.Title.Contains(title));
				}

				if (categoryId.HasValue)
				{
					// Directly filter by CategoryID (no need to fetch the category by name)
					query = query.Where(a => a.CategoryID == categoryId.Value);
				}

				var totalAds = query.Count();
				var totalPages = (int)Math.Ceiling((double)totalAds / pageSize);
				pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

				var ads = query
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize)
					.ToList();

				return ads;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while retrieving ads.");
				return StatusCode(StatusCodes.Status500InternalServerError, "Cannot find any ads.");
			}
		}
        [HttpGet("/ads/account/{accountId}")]
        [AllowAnonymous]
        public ActionResult<List<Ad>> GetAdsByAccountId(int accountId)
        {
                var ads = database.Ads
                    .Where(a => a.AccountID == accountId)
                    .ToList();

                return ads;
            
        }
        [HttpGet("/ads/count")]
        [AllowAnonymous]
        public ActionResult<int> GetTotalAdsCount(string? title = null, int? categoryId = null)
        {
            try
            {
                var query = database.Ads.AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(a => a.Title.Contains(title));
                }

                if (categoryId.HasValue)
                {
                    query = query.Where(a => a.CategoryID == categoryId);
                }

                var totalAds = query.Count();
                return totalAds;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while counting ads.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error counting ads");
            }
        }

        [HttpGet("/categories")]
        [AllowAnonymous]
        public ActionResult<List<Category>> GetCategories()
        {
            try
            {
				return database.categories.ToList();
			}
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching categories");
            }
        }

        [HttpGet("/ads/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Ad>> GetAd(int id)
        {
            try
            {
				var ad = await database.Ads.FindAsync(id);
				return ad;
			}
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,"Can not find the specified ad.");
            }
            
        }

        [HttpPost("/ads")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAd(Ad ad)
        {
            try
            {
                database.Ads.Add(ad);
                await database.SaveChangesAsync();
                return CreatedAtAction("GetAd", new { id = ad.ID }, ad);
            }
            catch (Exception ex)
            {
				_logger.LogError(ex.ToString());
				return StatusCode(StatusCodes.Status500InternalServerError, "Could not create ad.");
			}

        }
        [HttpPut("/ad/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAd(int id, Ad ad)
        {
            try
            {
				database.Ads.Update(ad);
                await database.SaveChangesAsync();
			}
            catch (Exception ex)
            {
				_logger.LogError(ex.ToString());
				return StatusCode(StatusCodes.Status500InternalServerError, "Could not update ad.");
			}
            return NoContent();
            
        }
        [HttpDelete("/ads/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAd(int id)
        {
            try
            {
                var ad = await database.Ads.FindAsync(id);
                database.Ads.Remove(ad);
                await database.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
				_logger.LogError(ex.ToString());
				return StatusCode(StatusCodes.Status500InternalServerError, "Ad could not be deleted.");
			}
        }
    }
}
