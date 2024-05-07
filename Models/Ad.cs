using System.ComponentModel.DataAnnotations.Schema;

namespace FogelFormedlingenAB.Models
{
    public class Ad
    {
        public int ID { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public int AccountID { get; set; } // AccountID
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
