using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FogelFormedlingenAB.Controllers
{
	[Route("")]
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

		[HttpGet("/ads/{adId}")]
		[AllowAnonymous]
		public async Task<ActionResult<Ad>> GetAd(int adId)
		{
			try
			{
				var ad = await database.Ads.FindAsync(adId);
				return ad;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.ToString());
				return StatusCode(StatusCodes.Status500InternalServerError, "Can not find the specified ad.");
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
				return Ok(ad);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.ToString());
				return StatusCode(StatusCodes.Status500InternalServerError, "Could not create ad.");
			}

		}
        [HttpPost("favourites")]
        [AllowAnonymous]
        public async Task<IActionResult> AddToFavourites([FromBody] Favourite favourite)  
        {
            try
            {
               
                database.Favourites.Add(favourite);
                await database.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding to favorites.");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("favourites/ads/{accountId}")] 
        [AllowAnonymous]
        public IActionResult GetLikedAds(int accountId)
        {
            try
            {
                var likedAds = database.Favourites
                   .Where(f => f.AccountID == accountId)
                   .Include(f => f.Ad) 
                   .Select(f => f.Ad)
                   .ToList();

                return Ok(likedAds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting liked ads.");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPut("/ads/{adId}")]
		[AllowAnonymous]
		public async Task<IActionResult> UpdateAd(Ad ad)
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
		[HttpDelete("/ads/{adId}")]
		[AllowAnonymous]
		public async Task<IActionResult> DeleteAd(int adId)
		{
			try
			{
				var ad = await database.Ads.FindAsync(adId);
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

		[HttpGet("/sampledata")]
		public async Task<IActionResult> AddSampleData()
		{
			if (database.Ads.Count() != 0)
			{
				return Forbid();
			}
			string jsonPath = "wwwroot/sample-data.json";
			var accountIDs = Helpers.GetAccountIDs(database);
			List<Ad> ads;
			using (StreamReader r = new StreamReader(jsonPath))
			{
				string json = r.ReadToEnd();
				ads = JsonConvert.DeserializeObject<List<Ad>>(json);
			}

			Random rand = new Random();

			if (ads != null)
			{
				List<string> imageUrls = await Helpers.GetPixabayPics("bird", ads.Count());
				for (int i = 0; i < ads.Count(); i++)
				{
					ads[i].AccountID = rand.Next(accountIDs.Min(), accountIDs.Max());
					ads[i].ImageUrl = imageUrls[i];
				}
				foreach (Ad ad in ads)
				{
					database.Ads.Add(ad);
				}
				database.SaveChanges();

			}
			else
			{
				return BadRequest();
			}

			return NoContent();
		}
        


        private class Helpers
		{

			public static async Task<List<string>> GetPixabayPics(string query, int resultAmount)
			{

				using (HttpClient client = new HttpClient())
				{
					try
					{
						string baseUrl = "https://pixabay.com/api/";
						string endpoint = "endpoint";
						string fullUrl = $"{baseUrl}?key=42110623-f962f4f597ca7cf92ce7360e7&q={query}&image_type=photo&per_page={resultAmount}";
						List<string> webformatUrls = new List<string>();
						HttpResponseMessage response = await client.GetAsync(fullUrl);

						if (response.IsSuccessStatusCode)
						{
							string responseBody = await response.Content.ReadAsStringAsync();

							// Deserialize the JSON response into a JObject
							JObject jsonResponse = JObject.Parse(responseBody);

							// Extract the "hits" array from the JObject
							JArray hitsArray = jsonResponse["hits"] as JArray;
							foreach (var hit in hitsArray)
							{
								string webformatUrl = hit["webformatURL"].ToString();
								webformatUrls.Add(webformatUrl);
							}
							return webformatUrls;
						}
						else
						{
							Console.WriteLine($"Error: {response.StatusCode}");
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine($"An error occurred: {ex.Message}");
					}
				}
				//Temp return to avoid errors during development 
				return null;
			}

			public static List<int> GetAccountIDs(AppDbContext database)
			{
				return database.Accounts.Select(x => x.ID).ToList();
			}
		}

	}
}
