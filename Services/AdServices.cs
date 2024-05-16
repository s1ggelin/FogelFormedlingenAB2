//the AdServices class serves as a layer between the user interface (or presentation layer) and the data access layer, which might be an API or a database.

using FogelFormedlingenAB.Models;
using Newtonsoft.Json;

namespace FogelFormedlingenAB.Services
{
	public class AdServices
	{
		private readonly HttpClient _httpClient; // This field holds an instance of HttpClient for making HTTP requests.

		// The constructor takes an instance of HttpClient as a parameter and assigns it to the _httpClient field.
		public AdServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		// This method retrieves a list of Ad objects from the API endpoint.
		public static async Task<List<Ad>> GetAds()
		{
			List<Ad> ads = new List<Ad>(); // Create an empty list to store the Ad objects.

			using (HttpClient client = new HttpClient()) // Create a new instance of HttpClient for this request.
			{
				try
				{
					// Set up the API endpoint URL.
					string baseUrl = "https://localhost:5000/";
					string endpoint = "ads";
					string fullUrl = baseUrl + endpoint;

					// Make a GET request to the API endpoint.
					HttpResponseMessage response = await client.GetAsync(fullUrl);

					// If the request is successful, deserialize the response body into a list of Ad objects.
					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						ads = JsonConvert.DeserializeObject<List<Ad>>(responseBody);
					}
					else
					{
						// If the request fails, log the error status code.
						Console.WriteLine($"Error: {response.StatusCode}");
					}
				}
				catch (Exception ex)
				{
					// If an exception occurs, log the error message.
					Console.WriteLine($"An error occurred: {ex.Message}");
				}
			}

			return ads; // Return the list of Ad objects.
		}
		public static async Task<Ad> GetAd(int adId)
		{
			Ad ad = null;
			using (HttpClient client = new HttpClient())
			{
				try
				{
					string baseUrl = "https://localhost:5000";
					string endpoint = $"/ads/{id}"; 
					string fullUrl = baseUrl + endpoint;

					// Make a GET request to the API endpoint.
					HttpResponseMessage response = await client.GetAsync(fullUrl);

					// If the request is successful, deserialize the response body into an Ad object.
					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						ad = JsonConvert.DeserializeObject<Ad>(responseBody);
					}
					else
					{
						// If the request fails, log the error status code.
						Console.WriteLine($"Error: {response.StatusCode}");
					}
				}
				catch (Exception ex)
				{
					// If an exception occurs, log the error message.
					Console.WriteLine($"An error occurred: {ex.Message}");
				}
				return ad; // Return the Ad object.
			}
		}

		// This method creates a new Ad object by sending a POST request to the API endpoint.
		public static async Task<bool> CreateAd(Ad newAd)
		{
			using (HttpClient client = new HttpClient()) // Create a new instance of HttpClient for this request.
			{
				try
				{
					// Set up the API endpoint URL.
					string baseUrl = "https://localhost:5000/";
					string endpoint = "ads";
					string fullUrl = baseUrl + endpoint;

					// Serialize the newAd object to JSON.
					var json = JsonConvert.SerializeObject(newAd);
					var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); // Create a StringContent with the JSON data.

					// Make a POST request to the API endpoint with the JSON data.
					HttpResponseMessage respone = await client.PostAsync(fullUrl, data);

					// If the request is successful, return true.
					if (respone.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						// If the request fails, log the error status code and return false.
						Console.WriteLine($"Error: {respone.StatusCode}");
						return false;
					}
				}
				catch (Exception ex)
				{
					// If an exception occurs, log the error message and return false.
					Console.WriteLine($"An error occurred: {ex.Message}");
					return false;
				}
			}
		}

		// This method updates an existing Ad object by sending a PUT request to the API endpoint.
		public static async Task<bool> UpdateAd(int adId, Ad updatedAd)
		{
			using (HttpClient client = new HttpClient()) // Create a new instance of HttpClient for this request.
			{
				try
				{
					// Set up the API endpoint URL with the ad ID.
					string baseUrl = "https://localhost:5000/";
					string endpoint = $"api/ad/{adId}";
					string fullUrl = baseUrl + endpoint;

					// Serialize the updatedAd object to JSON.
					var json = JsonConvert.SerializeObject(updatedAd);
					var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); // Create a StringContent with the JSON data.

					// Make a PUT request to the API endpoint with the JSON data.
					HttpResponseMessage response = await client.PutAsync(fullUrl, data);

					// If the request is successful, return true.
					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						// If the request fails, log the error status code and return false.
						Console.WriteLine($"Error: {response.StatusCode}");
						return false;
					}
				}
				catch (Exception ex)
				{
					// If an exception occurs, log the error message and return false.
					Console.WriteLine($"An error occurred: {ex.Message}");
					return false;
				}
			}
		}

		// This method deletes an existing Ad object by sending a DELETE request to the API endpoint.
		public static async Task<bool> DeleteAd(int adId)
		{
			using (HttpClient client = new HttpClient()) // Create a new instance of HttpClient for this request.
			{
				try
				{
					// Set up the API endpoint URL with the ad ID.
					string baseUrl = "https://localhost:5000/";
					string endpoint = $"api/ad/{adId}";
					string fullUrl = baseUrl + endpoint;

					// Make a DELETE request to the API endpoint.
					HttpResponseMessage response = await client.DeleteAsync(fullUrl);

					// If the request is successful, return true.
					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						// If the request fails, log the error status code and return false.
						Console.WriteLine($"Error: {response.StatusCode}");
						return false;
					}
				}
				catch (Exception ex)
				{
					// If an exception occurs, log the error message and return false.
					Console.WriteLine($"An error occurred: {ex.Message}");
					return false;
				}
			}
		}
	}
}