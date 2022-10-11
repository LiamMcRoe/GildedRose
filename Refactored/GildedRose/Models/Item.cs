namespace GildedRose.Models
{
	public class Item
	{
		public string Name { get; set; }
		public int SellIn { get; set; }
		public int Quality { get; set; }

		public override string ToString()
		{
			return Name + ", " + SellIn + ", " + Quality;
		}
	}

	/// <summary>
	/// The types of <see cref="Item"/>s available in the Gilded Rose shop.
	/// </summary>
	public enum ItemType
	{
		Standard,
		Legendary,
		Concert,
		Brie,
		Conjured
	}
}
