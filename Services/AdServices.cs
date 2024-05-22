//the AdServices class serves as a layer between the user interface (or presentation layer) and the data access layer, which might be an API or a database.

using FogelFormedlingenAB.Models;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

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
        public static async Task<List<Ad>> GetAds(int pageNumber = 1, string? title = null, int? categoryId = null, int pageSize = 10)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = "ads";
                    var queryParams = new Dictionary<string, string>
                    {
                        ["pageNumber"] = pageNumber.ToString(),
                        ["pageSize"] = pageSize.ToString()
                    };
                    if (!string.IsNullOrEmpty(title)) queryParams["title"] = title;
                    if (categoryId.HasValue)
                    {
                        queryParams["categoryId"] = categoryId.Value.ToString();
                    }

                    string fullUrl = QueryHelpers.AddQueryString(baseUrl + endpoint, queryParams);

                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Ad>>(responseBody);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Error fetching ads");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Network or API Error: {ex.Message}");
                    throw new HttpRequestException($"Error fetching ads:");

                }

            }
        }
        public static async Task<bool> CreateOrder(Order order)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000";
                    string endpoint = "/order";
                    string fullUrl = baseUrl + endpoint;

                    var json = JsonConvert.SerializeObject(order);
                    var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(fullUrl, data);

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

        public static async Task<List<Ad>> GetAdsByAccountId(int accountId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = $"ads/account/{accountId}"; //for personalized access
                    string fullUrl = baseUrl + endpoint;

                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Ad>>(responseBody);
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
            return new List<Ad>(); // Or handle the error more appropriately in your context
        }

        public static async Task<Ad> GetAd(int adId)
        {
            Ad ad = null;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = $"ads/{adId}";
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
                    string endpoint = $"ads/{adId}";
                    string fullUrl = baseUrl + endpoint;

                    // Serialize the updatedAd object to JSON.
                    var json = JsonConvert.SerializeObject(updatedAd);
                    var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); // Create a StringContent with the JSON data.

                    // Make a PUT request to the API endpoint with the JSON data.
                    HttpResponseMessage response = await client.PutAsync(fullUrl, data);

                    // If the request is successful, return true.
                    if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
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
                    // gives api endpoint url ad id
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = $"ads/{adId}";
                    string fullUrl = baseUrl + endpoint;

                    // Make a DELETE request to the API endpoint
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
        public static async Task<bool> AddToFavouritesAsync(Favourite newFavourite)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000";
                    string endpoint = "/api/favourites";
                    string fullUrl = baseUrl + endpoint;


                    var json = JsonConvert.SerializeObject(newFavourite);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");


                    HttpResponseMessage response = await client.PostAsync(fullUrl, data);


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
        public static async Task<bool> RemoveFromFavouritesAsync(int adId, int accountId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = $"api/favourites/{adId}/{accountId}";
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
        public static async Task<List<Ad>> GetLikedAds(int accountId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = $"api/favourites/ads/{accountId}";
                    string fullUrl = baseUrl + endpoint;

                    var response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Ad>>(content);
                    }
                    else
                    {

                        return new List<Ad>();
                    }
                }
                catch (Exception ex)
                {

                    return new List<Ad>();
                }
            }
        }
        public static async Task<List<Order>> GetOrderedAds(int accountId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = $"order/account/{accountId}";
                    string fullUrl = baseUrl + endpoint;

                    var response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Order>>(content);
                    }
                    else
                    {

                        return new List<Order>();
                    }
                }
                catch (Exception ex)
                {
                    return new List<Order>();
                }
            }
        }
        public static async Task<List<Category>> GetCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string baseUrl = "https://localhost:5000/";
                    string endpoint = "categories";
                    string fullUrl = baseUrl + endpoint;

                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Category>>(responseBody);
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
            return new List<Category>();
        }
        public static async Task<int> GetTotalPages(string? title = null, int? categoryId = null, int pageSize = 10)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    string baseUrl = "https://localhost:5000/";
                    string endpoint = "ads/count"; // points ads/count for calculus
                    var queryParams = new Dictionary<string, string>();
                    if (!string.IsNullOrEmpty(title)) queryParams["title"] = title;
                    if (categoryId.HasValue) queryParams["categoryId"] = categoryId.Value.ToString(); // Pass categoryId

                    string fullUrl = QueryHelpers.AddQueryString(baseUrl + endpoint, queryParams);

                    HttpResponseMessage response = await client.GetAsync(fullUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        int totalAds = JsonConvert.DeserializeObject<int>(responseBody);
                        return (int)Math.Ceiling((double)totalAds / pageSize);
                    }
                    else
                    {


                        Console.WriteLine($"Error fetching ad count");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");

                }
            }

            return 0;
        }
    }
}