using GildedRose.Models;

namespace GildedRose.Extensions
{
	/// <summary>
	/// Contains extension methods for the <see cref="Item"/> class.
	/// </summary>
	public static class ItemExtensions
	{
		/// <summary>
		/// Gets the <see cref="ItemType"/> associated with the given item using its name.
		/// </summary>
		/// <param name="item">The item for which to get the corresponding <see cref="ItemType"/>.</param>
		/// <returns>The <see cref="ItemType"/> associated with the given item.</returns>
		public static ItemType GetItemType(this Item item)
		{
			ArgumentNullException.ThrowIfNull(item);
			return item.Name switch
			{
				"Sulfuras, Hand of Ragnaros" => ItemType.Legendary,
				"Aged Brie" => ItemType.Brie,
				"Backstage passes to a TAFKAL80ETC concert" => ItemType.Concert,
				"Conjured Mana Cake" => ItemType.Conjured,
				_ => ItemType.Standard
			};
		}
	}
}
