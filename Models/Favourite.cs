namespace FogelFormedlingenAB.Models
{
    public class Favourite
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public Account Account { get; set; }
        public required int AdID { get; set; }
        public Ad Ad {  get; set; }

    }
}
