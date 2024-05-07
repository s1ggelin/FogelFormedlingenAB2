﻿using FogelFormedlingenAB.Models;

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
				database.Ads.Add(new Ad
				{
					PictureUrl = "philippine-eagle.jpg",
					Description = "Upplev majestätet hos en Philippine Eagle, en symbol för styrka och skönhet. Denna imponerande fågel är nu tillgänglig för en ny ägare som uppskattar dess unika charm och sällsynthet.",
					Category = "Asiatisk Fågel",
					IsActive = true,
					AccountID = 3,
					Price = 1337,
					Title = "Unik Philippine Eagle till supererbjudande",
					StartDate = "2024-06-25",
					EndDate = "2024-07-04"

				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Ge ditt hem en exotisk touch genom att adoptera en påfågel idag! Dessa vackra och majestätiska fåglar är kända för sina spektakulära fjäderskrudar och eleganta beteende.",
					Category = "Påfågel",
					IsActive = true,
					AccountID = 7,
					Price = 2000,
					Title = "Adoptera en Påfågel - Skönhet och Elegans!",
					StartDate = "2024-05-10",
					EndDate = "2024-06-10"

				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Upptäck spänningen med att äga en rovfågel genom att adoptera en hök idag! Dessa snabba och skickliga jägare är fascinerande att se i aktion.",
					Category = "Hök",
					IsActive = true,
					AccountID = 8,
					Price = 1800,
					Title = "Adoptera en Hök - Fångaren av Skyn!",
					StartDate = "2024-05-11",
					EndDate = "2024-06-11"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Ge ditt hem en touch av elegans genom att adoptera en svan idag! Dessa anmärkningsvärda fåglar är symboler för kärlek, skönhet och fred.",
					Category = "Svan",
					IsActive = true,
					AccountID = 9,
					Price = 2500,
					Title = "Adoptera en Svan - Symbol för Kärlek och Skönhet!",
					StartDate = "2024-05-12",
					EndDate = "2024-06-12"
				});

				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Upptäck skönheten och charmen hos en kolibri genom att adoptera en idag! Dessa små och färgglada fåglar är kända för sin snabbhet och smidighet i luften.",
					Category = "Kolibri",
					IsActive = true,
					AccountID = 10,
					Price = 1200,
					Title = "Adoptera en Kolibri - Ett Vackert Luftakrobat!",
					StartDate = "2024-05-13",
					EndDate = "2024-06-13"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Förvandla ditt hem till en tropisk oas genom att adoptera en tukan idag! Dessa färgstarka och lekfulla fåglar kommer att föra glädje och färg till ditt liv.",
					Category = "Tukan",
					IsActive = true,
					AccountID = 11,
					Price = 1800,
					Title = "Adoptera en Tukan - Färg och Glädje!",
					StartDate = "2024-05-14",
					EndDate = "2024-06-14"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Ge ditt hem en touch av mystik genom att adoptera en uggla idag! Dessa lugna och intelligenta fåglar är symboler för visdom och skydd.",
					Category = "Uggla",
					IsActive = true,
					AccountID = 12,
					Price = 1500,
					Title = "Adoptera en Uggla - Symbol för Visdom och Skydd!",
					StartDate = "2024-05-15",
					EndDate = "2024-06-15"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Förvandla ditt hem till en djungel genom att adoptera en papegoja idag! Dessa kvicka och pratglada fåglar kommer att föra liv och energi till ditt hem.",
					Category = "Papegoja",
					IsActive = true,
					AccountID = 13,
					Price = 2000,
					Title = "Adoptera en Papegoja - Kvick och Pratglad!",
					StartDate = "2024-05-16",
					EndDate = "2024-06-16"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Upptäck skönheten i naturen genom att adoptera en koltrast idag! Dessa sångfåglar är kända för sin vackra sång och eleganta fjäderdräkt.",
					Category = "Koltrast",
					IsActive = true,
					AccountID = 14,
					Price = 800,
					Title = "Adoptera en Koltrast - Sångens Skönhet!",
					StartDate = "2024-05-17",
					EndDate = "2024-06-17"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Ge ditt hem en touch av exotisk charm genom att adoptera en flamingo idag! Dessa eleganta fåglar är kända för sina långa ben och rosa fjädrar.",
					Category = "Flamingo",
					IsActive = true,
					AccountID = 15,
					Price = 2200,
					Title = "Adoptera en Flamingo - Elegans och Charm!",
					StartDate = "2024-05-18",
					EndDate = "2024-06-18"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Förvandla ditt hem till en djungel genom att adoptera en papegoja idag! Dessa kvicka och pratglada fåglar kommer att föra liv och energi till ditt hem.",
					Category = "Papegoja",
					IsActive = true,
					AccountID = 16,
					Price = 2000,
					Title = "Adoptera en Papegoja - Kvick och Pratglad!",
					StartDate = "2024-05-19",
					EndDate = "2024-06-19"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Ge ditt hem en touch av exotisk charm genom att adoptera en flamingo idag! Dessa eleganta fåglar är kända för sina långa ben och rosa fjädrar.",
					Category = "Flamingo",
					IsActive = true,
					AccountID = 17,
					Price = 2200,
					Title = "Adoptera en Flamingo - Elegans och Charm!",
					StartDate = "2024-05-20",
					EndDate = "2024-06-20"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Upplev skönheten och mystiken hos en uggla genom att adoptera en idag! Ugglor är inte bara symboler för visdom utan också fantastiska jägare och skyddare av naturen.",
					Category = "Uggla",
					IsActive = true,
					AccountID = 18,
					Price = 1000,
					Title = "Adoptera en Uggla - En Symbol för Visdom!",
					StartDate = "2024-05-21",
					EndDate = "2024-06-21"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Få en smak av tropikerna genom att adoptera en färgglad ara idag! Dessa intelligenta och färgrika fåglar är perfekta sällskapsdjur för den som söker något utöver det vanliga.",
					Category = "Ara",
					IsActive = true,
					AccountID = 19,
					Price = 1500,
					Title = "Adoptera en Ara - Färgglad Vän från Tropikerna!",
					StartDate = "2024-05-22",
					EndDate = "2024-06-22"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Få en smak av Australien genom att adoptera en kakadua idag! Dessa högljudda men charmiga fåglar är kända för sina färgglada fjädrar och lekfulla personligheter.",
					Category = "Kakadua",
					IsActive = true,
					AccountID = 20,
					Price = 1200,
					Title = "Adoptera en Kakadua - Australiens Charm!",
					StartDate = "2024-05-23",
					EndDate = "2024-06-23"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Upplev skönheten i naturen genom att adoptera en koltrast idag! Dessa sångfåglar är kända för sin vackra sång och eleganta fjäderdräkt.",
					Category = "Koltrast",
					IsActive = true,
					AccountID = 21,
					Price = 800,
					Title = "Adoptera en Koltrast - Sångens Skönhet!",
					StartDate = "2024-05-24",
					EndDate = "2024-06-24"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Förvandla ditt hem till en tropisk oas genom att adoptera en tukan idag! Dessa färgstarka och lekfulla fåglar kommer att föra glädje och färg till ditt liv.",
					Category = "Tukan",
					IsActive = true,
					AccountID = 22,
					Price = 1800,
					Title = "Adoptera en Tukan - Färg och Glädje!",
					StartDate = "2024-05-25",
					EndDate = "2024-06-25"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Få en smak av Australien genom att adoptera en kakadua idag! Dessa högljudda men charmiga fåglar är kända för sina färgglada fjädrar och lekfulla personligheter.",
					Category = "Kakadua",
					IsActive = true,
					AccountID = 23,
					Price = 1200,
					Title = "Adoptera en Kakadua - Australiens Charm!",
					StartDate = "2024-05-26",
					EndDate = "2024-06-26"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Upplev skönheten i naturen genom att adoptera en koltrast idag! Dessa sångfåglar är kända för sin vackra sång och eleganta fjäderdräkt.",
					Category = "Koltrast",
					IsActive = true,
					AccountID = 24,
					Price = 800,
					Title = "Adoptera en Koltrast - Sångens Skönhet!",
					StartDate = "2024-05-27",
					EndDate = "2024-06-27"
				});
				database.Ads.Add(new Ad
				{
					PictureUrl = "placeholder.jpg",
					Description = "Ge ditt hem en touch av exotisk charm genom att adoptera en flamingo idag! Dessa eleganta fåglar är kända för sina långa ben och rosa fjädrar.",
					Category = "Flamingo",
					IsActive = true,
					AccountID = 25,
					Price = 2200,
					Title = "Adoptera en Flamingo - Elegans och Charm!",
					StartDate = "2024-05-28",
					EndDate = "2024-06-28"
				});
				database.SaveChanges();
			}
        }
    }
}
