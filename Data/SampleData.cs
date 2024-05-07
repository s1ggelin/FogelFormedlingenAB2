using FogelFormedlingenAB.Models;

namespace FogelFormedlingenAB.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will"
                });
            }

            database.SaveChanges();
        }
        public static void CreateAds(AppDbContext database)
        {
            if(!database.Ads.Any())
            {
                database.Ads.Add(new Ad
                {
                    PictureUrl = "fiskmås-svante.jpg",
                    Description = "En fin mås jag haft i trädgården. Lyssnar till namnet Svante och äter endast sardiner. Cirka 3 år gammal. Fint skick. BVSA!",
                    Category = "Svensk Fågel",
                    IsActive = true,
                    AccountID = 1,
                    Price = 499,
                    Title = "3 årig fin fiskmås!",
                    StartDate = "2024-05-06",
                    EndDate = "2024-06-06"
                });
				database.Ads.Add(new Ad
				{
					PictureUrl = "marabou-sven.jpg",
					Description = "Dags att sälja min pärla! Sven är en 5-årig marabou-stork. Van vid barn. Säljes pga ändrade livsförhållanden!!",
					Category = "Utländsk Fågel",
					IsActive = true,
					AccountID = 2,
					Price = 700,
					Title = "Marabou-Stork söker nytt hem",
					StartDate = "2024-05-06",
					EndDate = "2024-06-06"
				});
                database.SaveChanges();
			}
        }
    }
}
