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
        
        public static void CreateCategorys(AppDbContext database)
        {
            if (!database.categories.Any())
            {
                database.categories.Add(new Category
                {
                    Name = "Havsfågel"
                });

                database.categories.Add(new Category
                {
                    Name = "Skogsfågel"
                });

                database.categories.Add(new Category
                {
                    Name = "Exotisk Fågel"
                });

                database.categories.Add(new Category
                {
                    Name = "Sällskapsfågel"
                });

                database.categories.Add(new Category
                {
                    Name = "Jordbruksfågel"
                });

                database.categories.Add(new Category
                {
                    Name = "Rovfågel"
                });

                
            }
            database.SaveChanges();
        }
    }
}


