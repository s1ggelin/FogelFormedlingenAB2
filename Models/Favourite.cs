namespace FogelFormedlingenAB.Models
{
    public class Favourite
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public required Account Account { get; set; }
        public required int AdID { get; set; }
        public required Ad Ad {  get; set; }

    }
}
