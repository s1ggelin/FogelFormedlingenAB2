using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FogelFormedlingenAB.Models
{
    public class Ad
    {
        public int ID { get; set; }
        public int AccountID { get; set; } // AccountID
        public int PictureID { get; set; }
        public int CategoryID { get; set; }
		[MaxLength(50)]
		public string Title { get; set; }
		[MaxLength(500)]
		public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
		public DateTime StartDate { get; set; }

    }
}
