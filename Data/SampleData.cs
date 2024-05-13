using FogelFormedlingenAB.Models;

namespace FogelFormedlingenAB.Data
{
    public class SampleData
    {
        public static void CreateAccounts(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad",
                    Email = "brad@example.com",
                    Phonenumber = "555-1111-1111"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina",
                    Email = "angelina@example.com",
                    Phonenumber = "555-2222-2222"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will",
                    Email = "will@example.com",
                    Phonenumber = "555-3333-3333"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "4444444444",
                    Name = "Frodo",
                    Email = "frodo@example.com",
                    Phonenumber = "555-4444-4444"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "5555555555",
                    Name = "Gandalf",
                    Email = "gandalf@example.com",
                    Phonenumber = "555-5555-5555"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "6666666666",
                    Name = "Aragorn",
                    Email = "aragorn@example.com",
                    Phonenumber = "555-6666-6666"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "7777777777",
                    Name = "Legolas",
                    Email = "legolas@example.com",
                    Phonenumber = "555-7777-7777"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "8888888888",
                    Name = "Gimli",
                    Email = "gimli@example.com",
                    Phonenumber = "555-8888-8888"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "9999999999",
                    Name = "Boromir",
                    Email = "boromir@example.com",
                    Phonenumber = "555-9999-9999"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1010101010",
                    Name = "Faramir",
                    Email = "faramir@example.com",
                    Phonenumber = "555-1010-1010"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1212121212",
                    Name = "Pippin",
                    Email = "pippin@example.com",
                    Phonenumber = "555-1212-1212"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1313131313",
                    Name = "Merry",
                    Email = "merry@example.com",
                    Phonenumber = "555-1313-1313"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1414141414",
                    Name = "Sauron",
                    Email = "sauron@example.com",
                    Phonenumber = "555-1414-1414"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1515151515",
                    Name = "Saruman",
                    Email = "saruman@example.com",
                    Phonenumber = "555-1515-1515"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1616161616",
                    Name = "Galadriel",
                    Email = "galadriel@example.com",
                    Phonenumber = "555-1616-1616"
                });

                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1717171717",
                    Name = "Elrond",
                    Email = "elrond@example.com",
                    Phonenumber = "555-1717-1717"
                });
            }


            database.SaveChanges();
        }
        public static void CreateAds(AppDbContext database)
        {
            if (!database.Ads.Any())
            {
				if (!database.Images.Any())
                {
                    for (int i = 0; i <= 23; i++)
                    {
                        database.Images.Add(new Image
                        {
                            ImageUrl = ""
                        });

						}
                    }
				database.SaveChanges();

				database.Ads.Add(new Ad
                {
                    ImageID = 1,
                    Description = "Adoptera en Hök - Fångaren av Skyn!",
                    CategoryID = 2,
                    IsActive = true,
                    AccountID = 1,
                    Price = 1800,
                    Title = "Adoptera en Hök - Fångaren av Skyn!",
                    StartDate = DateTime.Parse("2024-05-11"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 2,
                    Description = "Adoptera en Svan - Symbol för Kärlek och Skönhet!",
                    CategoryID = 3,
                    IsActive = true,
                    AccountID = 1,
                    Price = 2500,
                    Title = "Adoptera en Svan - Symbol för Kärlek och Skönhet!",
                    StartDate = DateTime.Parse("2024-05-12"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 3,
                    Description = "Adoptera en Kolibri - Ett Vackert Luftakrobat!",
                    CategoryID = 4,
                    IsActive = true,
                    AccountID = 2,
                    Price = 1200,
                    Title = "Adoptera en Kolibri - Ett Vackert Luftakrobat!",
                    StartDate = DateTime.Parse("2024-05-13"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 4,
                    Description = "Adoptera en Tukan - Färg och Glädje!",
                    CategoryID = 5,
                    IsActive = true,
                    AccountID = 2,
                    Price = 1800,
                    Title = "Adoptera en Tukan - Färg och Glädje!",
                    StartDate = DateTime.Parse("2024-05-14"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 5,
                    Description = "Adoptera en Uggla - Symbol för Visdom och Skydd!",
                    CategoryID = 6,
                    IsActive = true,
                    AccountID = 3,
                    Price = 1500,
                    Title = "Adoptera en Uggla - Symbol för Visdom och Skydd!",
                    StartDate = DateTime.Parse("2024-05-15"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 6,
                    Description = "Adoptera en Papegoja - Kvick och Pratglad!",
                    CategoryID = 7,
                    IsActive = true,
                    AccountID = 3,
                    Price = 2000,
                    Title = "Adoptera en Papegoja - Kvick och Pratglad!",
                    StartDate = DateTime.Parse("2024-05-16"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 7,
                    Description = "Adoptera en Koltrast - Sångens Skönhet!",
                    CategoryID = 8,
                    IsActive = true,
                    AccountID = 4,
                    Price = 800,
                    Title = "Adoptera en Koltrast - Sångens Skönhet!",
                    StartDate = DateTime.Parse("2024-05-17"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 8,
                    Description = "Adoptera en Flamingo - Elegans och Charm!",
                    CategoryID = 9,
                    IsActive = true,
                    AccountID = 4,
                    Price = 2200,
                    Title = "Adoptera en Flamingo - Elegans och Charm!",
                    StartDate = DateTime.Parse("2024-05-18"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 9,
                    Description = "Adoptera en Ara - Färgglad Vän från Tropikerna!",
                    CategoryID = 10,
                    IsActive = true,
                    AccountID = 5,
                    Price = 1500,
                    Title = "Adoptera en Ara - Färgglad Vän från Tropikerna!",
                    StartDate = DateTime.Parse("2024-05-22"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 10,
                    Description = "Adoptera en Kakadua - Australiens Charm!",
                    CategoryID = 11,
                    IsActive = true,
                    AccountID = 5,
                    Price = 1200,
                    Title = "Adoptera en Kakadua - Australiens Charm!",
                    StartDate = DateTime.Parse("2024-05-23"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 11,
                    Description = "Få en smak av Karibien genom att adoptera en pelikan idag! Dessa storslagna fåglar är kända för sina stora näbbar och förmågan att dyka efter fisk.",
                    CategoryID = 12,
                    IsActive = true,
                    AccountID = 6,
                    Price = 2500,
                    Title = "Adoptera en Pelikan - Storslagen Fiskare från Karibien!",
                    StartDate = DateTime.Parse("2024-05-29"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 12,
                    Description = "Få en smak av Afrika genom att adoptera en struts idag! Dessa stolta och snabba löpare är kända för sin elegans och styrka.",
                    CategoryID = 13,
                    IsActive = true,
                    AccountID = 6,
                    Price = 3000,
                    Title = "Adoptera en Struts - Elegans och Styrka från Afrika!",
                    StartDate = DateTime.Parse("2024-05-30"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 13,
                    Description = "Upptäck skönheten i naturen genom att adoptera en fasan idag! Dessa färgglada och imponerande fåglar är perfekta för den som uppskattar en unik och exotisk djurupplevelse.",
                    CategoryID = 14,
                    IsActive = true,
                    AccountID = 7,
                    Price = 1800,
                    Title = "Adoptera en Fasan - Färgglad Skönhet från Naturen!",
                    StartDate = DateTime.Parse("2024-05-31"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 14,
                    Description = "Upplev skönheten i naturen genom att adoptera en kondor idag! Dessa storslagna rovfåglar är symboler för kraft och frihet.",
                    CategoryID = 15,
                    IsActive = true,
                    AccountID = 7,
                    Price = 4000,
                    Title = "Adoptera en Kondor - Symbol för Kraft och Frihet!",
                    StartDate = DateTime.Parse("2024-06-01"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 15,
                    Description = "Få en smak av Antarktis genom att adoptera en pingvin idag! Dessa charmiga och sociala fåglar kommer att sprida glädje och skratt i ditt hem.",
                    CategoryID = 16,
                    IsActive = true,
                    AccountID = 8,
                    Price = 1500,
                    Title = "Adoptera en Pingvin - Charm och Glädje från Antarktis!",
                    StartDate = DateTime.Parse("2024-06-02"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 16,
                    Description = "Upptäck den nordiska mytologin genom att adoptera en valkyria idag! Dessa majestätiska kvinnliga krigare är kända för sin styrka och skönhet.",
                    CategoryID = 17,
                    IsActive = true,
                    AccountID = 8,
                    Price = 5000,
                    Title = "Adoptera en Valkyria - Majestätisk Krigare från Nordisk Mytologi!",
                    StartDate = DateTime.Parse("2024-06-03"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 17,
                    Description = "Få en smak av Amazonas genom att adoptera en toekan idag! Dessa färgglada och livliga fåglar är kända för sina stora näbbar och spektakulära fjädrar.",
                    CategoryID = 18,
                    IsActive = true,
                    AccountID = 9,
                    Price = 2200,
                    Title = "Adoptera en Toekan - Färgprakt från Amazonas!",
                    StartDate = DateTime.Parse("2024-06-04"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 18,
                    Description = "Få en smak av Hawaii genom att adoptera en albatross idag! Dessa eleganta flygare är kända för sina långa vingspann och förmågan att flyga över stora oceaner.",
                    CategoryID = 19,
                    IsActive = true,
                    AccountID = 9,
                    Price = 2800,
                    Title = "Adoptera en Albatross - Flygande Skönhet från Hawaii!",
                    StartDate = DateTime.Parse("2024-06-05"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 19,
                    Description = "Upplev skönheten i naturen genom att adoptera en sparv idag! Dessa små och kvicka fåglar är kända för sin livlighet och sångglädje.",
                    CategoryID = 20,
                    IsActive = true,
                    AccountID = 10,
                    Price = 500,
                    Title = "Adoptera en Sparv - Liten men Livfull!",
                    StartDate = DateTime.Parse("2024-06-06"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 20,
                    Description = "Få en smak av Australien genom att adoptera en emu idag! Dessa stora och snabba löpare är kända för sin karaktäristiska utseende och starka personligheter.",
                    CategoryID = 21,
                    IsActive = true,
                    AccountID = 10,
                    Price = 3200,
                    Title = "Adoptera en Emu - Australiens Stolta Flykting!",
                    StartDate = DateTime.Parse("2024-06-07"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 21,
                    Description = "Upptäck skönheten i naturen genom att adoptera en fregattfågel idag! Dessa storslagna flygare är kända för sin förmåga att segla långa sträckor över havet.",
                    CategoryID = 22,
                    IsActive = true,
                    AccountID = 11,
                    Price = 2700,
                    Title = "Adoptera en Fregattfågel - Seglande Skönhet från Haven!",
                    StartDate = DateTime.Parse("2024-06-08"),
                });

                database.Ads.Add(new Ad
                {
                    ImageID = 22,
                    Description = "Få en smak av Afrika genom att adoptera en guineafågel idag! Dessa färgglada och sociala fåglar är perfekta sällskapsdjur för den som uppskattar unika djurupplevelser.",
                    CategoryID = 23,
                    IsActive = true,
                    AccountID = 11,
                    Price = 1900,
                    Title = "Adoptera en Guineafågel - Färgglad Vän från Afrika!",
                    StartDate = DateTime.Parse("2024-06-09"),
                });
				database.Ads.Add(new Ad
				{
					ImageID = 23,
					Description = "JAG HAR FÅGEL! \nDU BETALA FÅGEL",
					CategoryID = 23,
					IsActive = true,
					AccountID = 11,
					Price = 1900,
					Title = "DU INTE FÅGEL",
					StartDate = DateTime.Parse("2024-06-09"),
				});


				database.SaveChanges();
            }

        }
        public static void CreateCategorys(AppDbContext database)
        {
            if (!database.categories.Any())
            {
                database.categories.Add(new Category
                {
                    Name = "Påfågel"
                });

                database.categories.Add(new Category
                {
                    Name = "Hök"
                });

                database.categories.Add(new Category
                {
                    Name = "Svan"
                });

                database.categories.Add(new Category
                {
                    Name = "Kolibri"
                });

                database.categories.Add(new Category
                {
                    Name = "Tukan"
                });

                database.categories.Add(new Category
                {
                    Name = "Uggla"
                });

                database.categories.Add(new Category
                {
                    Name = "Papegoja"
                });

                database.categories.Add(new Category
                {
                    Name = "Koltrast"
                });

                database.categories.Add(new Category
                {
                    Name = "Flamingo"
                });

                database.categories.Add(new Category
                {
                    Name = "Ara"
                });

                database.categories.Add(new Category
                {
                    Name = "Kakadua"
                });

                database.categories.Add(new Category
                {
                    Name = "Pelikan"
                });

                database.categories.Add(new Category
                {
                    Name = "Struts"
                });

                database.categories.Add(new Category
                {
                    Name = "Fasan"
                });

                database.categories.Add(new Category
                {
                    Name = "Kondor"
                });

                database.categories.Add(new Category
                {
                    Name = "Pingvin"
                });

                database.categories.Add(new Category
                {
                    Name = "Valkyria"
                });

                database.categories.Add(new Category
                {
                    Name = "Toekan"
                });

                database.categories.Add(new Category
                {
                    Name = "Albatross"
                });

                database.categories.Add(new Category
                {
                    Name = "Sparv"
                });

                database.categories.Add(new Category
                {
                    Name = "Emu"
                });

                database.categories.Add(new Category
                {
                    Name = "Fregattfågel"
                });

                database.categories.Add(new Category
                {
                    Name = "Guineafågel"
                });
            }
            database.SaveChanges();
        }
    }
}


