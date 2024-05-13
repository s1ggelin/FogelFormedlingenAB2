using System.ComponentModel.DataAnnotations;

namespace FogelFormedlingenAB.Models
{
    public class Image
    {
        
        public int ID { get; set; }
		[MaxLength(100)]
		public required string ImageUrl { get; set; }
        public int AdID { get; set; }
        public List<Ad> Ad { get; set; }
    }
}
