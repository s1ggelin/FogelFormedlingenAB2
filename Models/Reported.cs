using System.ComponentModel.DataAnnotations;

namespace FogelFormedlingenAB.Models
{
    public class Reported
    {
        public int ID { get; set; }
        public int ReportedByID { get; set; }
        public int? AdID { get; set; }
        public int? AccountID { get; set; }
		[MaxLength(500)]
		public string Description { get; set; }
    }
}
