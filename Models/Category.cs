namespace FogelFormedlingenAB.Models
{
	public class Category
	{
		public int ID { get; set; }
		public required string Name { get; set; }
		public Ad Ad { get; set; }
	}
}
