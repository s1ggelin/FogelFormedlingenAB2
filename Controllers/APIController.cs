using FogelFormedlingenAB.Data;
using FogelFormedlingenAB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FogelFormedlingenAB.Controllers
{
	[Route("/api")]
	[ApiController]
	public class APIController : ControllerBase
	{
		private readonly AppDbContext database;

		public APIController(AppDbContext database)
		{
			this.database = database;
		}

		[HttpGet("/sampledata")]
		public async Task<IActionResult> AddSampleData()
		{
			if (database.Ads != null) 
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
				foreach (Ad ad in ads) { 
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
				List<string> objects = new List<string>();

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
