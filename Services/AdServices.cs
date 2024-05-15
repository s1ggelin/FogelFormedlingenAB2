using FogelFormedlingenAB.Models;
using FogelFormedlingenAB.Controllers;
using FogelFormedlingenAB.Data;
using System.Text.Json;
using System.Net.Http;
using Newtonsoft.Json;



namespace FogelFormedlingenAB.Services

{
	public class AdServices
	{
		private readonly HttpClient _httpClient;

		
		public AdServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public static async Task<List<Ad>> GetAds()
		{
			List<Ad> ads = new List<Ad>();

			using (HttpClient client = new HttpClient())
			{
				try
				{
					string baseUrl = "https://localhost:5000/";
					string endpoint = "ads";
					string fullUrl = baseUrl + endpoint;

					HttpResponseMessage response = await client.GetAsync(fullUrl);

					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();

						
						ads = JsonConvert.DeserializeObject<List<Ad>>(responseBody);
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

			return ads;
		}
	}
}
