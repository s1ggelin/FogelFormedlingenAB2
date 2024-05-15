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
		public async Task<List<string>> AddSampleData(string data)
        {
			/*                                .    .-.;;;;;;'           .-._.;;;'           .:              /\                                  .-.                                  */
			/* .;.       .-..;            ...;... (_)  .; .;           (_).;                ::          _  / |              .;.       .-.      (_) )-.           .-.                 */
			/*   `;     ;'  ;;-. .-.       .'          :  ;;-.  .-.      .:--.,  :   .-.    ;;.-.      (  /  |  ..;.::..-.    `;     ;' .-.      .:   \   .-.    `-' . ,';.  ,:.,'   */
			/*    ;;    ;  ;;  ;;   :    .;          .:' ;;  ;.;.-'     .:'  ;   ;  ;       ;; .'       `/.__|_.'.;  .;.-'     ;;    ;.;.-'     .:'    \ ;   ;' ;'   ;;  ;; :   ;    */
			/*   ;;  ;  ;;.;`  ``:::'-'.;          .-:._.;`  ` `:::'  .-:  .'`..:;._`;;;;'_.'`  `.  .:' /    | .;'    `:::'   ;;  ;  ;;`:::'  .-:.      )`;;'_.;:._.';  ;;   `-:'    */
			/*   `;.' `.;'                        (_/  `-            (_/                           (__.'     `-'              `;.' `.;'      (_/  `----'            ;    `.-._:'     */
			var accountIDs = Helpers.GetAccountIDs(database);
			List<string> images = await Helpers.GetPixabayPics("bird", 40);
			List<string> objects = new List<string>();

			return images;
		}

    }
}
 public class Helpers
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