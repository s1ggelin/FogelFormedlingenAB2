using System.ComponentModel.DataAnnotations;

namespace FogelFormedlingenAB.Models
{
    public class Image
    {
        //default id 0 so use that as default img for missing img
        public int ID { get; set; }
		[MaxLength(100)]
		public required string PictureUrl { get; set; }
        public int AdID { get; set; }
        public required List<Ad> Ad { get; set; }
    }
}
