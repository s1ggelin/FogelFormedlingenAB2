using FogelFormedlingenAB.Models;
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
		public static async Task<Ad> GetAd(int adId)
		{
			Ad ad = null;

			using (HttpClient client = new HttpClient())
			{
				try
				{
					string baseUrl = "https://localhost:5000/";
					string endpoint = $"api/ads/{adId}";
					string fullUrl = baseUrl + endpoint;

					HttpResponseMessage response = await client.GetAsync(fullUrl);

					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();


						ad = JsonConvert.DeserializeObject<Ad>(responseBody);
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
				return ad;
			}
		}
		public static async Task<bool> CreateAd(Ad newAd)
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					string baseUrl = "https://localhost:5000/";
					string endpoint = "ads";
					string fullUrl = baseUrl + endpoint;

					var json = JsonConvert.SerializeObject(newAd);
					var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

					HttpResponseMessage respone = await client.PostAsync(fullUrl, data);

					if (respone.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						Console.WriteLine($"Error: {respone.StatusCode}");
						return false;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred: {ex.Message}");
					return false;
				}
			}
		}
		public static async Task<bool> UpdateAd(int adId, Ad updatedAd)
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					string baseUrl = "https://localhost:5000/";
					string endpoint = $"api/ad/{adId}";
					string fullUrl = baseUrl + endpoint;
					var json = JsonConvert.SerializeObject(updatedAd);
					var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
					HttpResponseMessage response = await client.PutAsync(fullUrl, data);
					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						Console.WriteLine($"Error: {response.StatusCode}");
						return false;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred: {ex.Message}");
					return false;
				}
			}
		}
		public static async Task<bool> DeleteAd(int adId)
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					string baseUrl = "https://localhost:5000/";
					string endpoint = $"api/ad/{adId}";
					string fullUrl = baseUrl + endpoint;
					HttpResponseMessage response = await client.DeleteAsync(fullUrl);
					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						Console.WriteLine($"Error: {response.StatusCode}");
						return false;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred: {ex.Message}");
					return false;
				}
			}
		}
	}
}