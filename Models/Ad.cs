using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FogelFormedlingenAB.Models
{
    public class Ad
    {
        public int ID { get; set; }

        public int AccountID { get; set; } // AccountID
		public required Account Account { get; set; }
        public int PictureID { get; set; }
        public required Image Picture { get; set; }
        public int CategoryID { get; set; }
        public required Category Category { get; set; }
		[MaxLength(50)]
		public required string Title { get; set; }
		[MaxLength(500)]
		public required string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
		public DateTime StartDate { get; set; }

        public Order? Order { get; set; }
        public Favourite? Favourite { get; set; }
    }
}
