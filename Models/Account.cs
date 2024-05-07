using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FogelFormedlingenAB.Models
{
    public class Account
    {
        public int ID { get; set; }
		public string OpenIDIssuer { get; set; }
		public string OpenIDSubject { get; set; }
		[MaxLength(25)]
		public string Name { get; set; }
		[MaxLength(20)]
		public string Phonenumber { get; set; }
		[MaxLength(50)]
		public string Email { get; set; }
    }
}
