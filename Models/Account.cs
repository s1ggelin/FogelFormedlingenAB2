using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FogelFormedlingenAB.Models
{
    public class Account
    {
        public int ID { get; set; }
		public required string OpenIDIssuer { get; set; }
		public required string OpenIDSubject { get; set; }
		[MaxLength(25)]
		public required string Name { get; set; }

		[MaxLength(20)]
		public required string Phonenumber { get; set; }
		[MaxLength(50)]
		public required string Email { get; set; }

		public List<Reported>? Reports { get; set; }
		public List<Favourite>? Favourites { get; set; }
		public List<Order>? Orders { get; set; }
		public List<Ad>? Ads { get; set; }
	}
}
