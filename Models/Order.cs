namespace FogelFormedlingenAB.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int AccountId { get; set; }
		public Account Account { get; set; }
        public int AdID { get; set; }
		public required Ad Ad { get; set; }
        public DateTime BoughtDate { get; set; }
    }
}
