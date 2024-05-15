using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FogelFormedlingenAB.Models
{
    public class Ad
    {
        public int ID { get; set; }

        public int AccountID { get; set; } // AccountID
		public Account Account { get; set; }
        public int ImageID { get; set; }
        public Image Image { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
		[MaxLength(80)]
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

