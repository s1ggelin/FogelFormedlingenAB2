using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FogelFormedlingenAB.Models
{
    public class Reported
    {
        public int ID { get; set; }
		public int ReportedByID { get; set; }
		public int? AdID { get; set; }
		public Ad? Ad {  get; set; }
		public int? AccountID { get; set; }
        public Account? Account { get; set; }
		[MaxLength(500)]
		public required string Description { get; set; }

    }
}
