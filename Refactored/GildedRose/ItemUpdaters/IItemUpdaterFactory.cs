using GildedRose.Models;

namespace GildedRose.ItemUpdaters
{
	/// <summary>
	/// Defines a factory for the creation of <see cref="ItemUpdater"/> classes.
	/// </summary>
	public interface IItemUpdaterFactory
	{
		/// <summary>
		/// Creates a specific instance of <see cref="ItemUpdater"/> based on the <see cref="ItemType"/> associated with the given item.
		/// </summary>
		/// <param name="item">The <see cref="Item"/> for which to create the <see cref="ItemUpdater"/>.</param>
		/// <returns>An instance of an <see cref="ItemUpdater"/> implementation based on the <see cref="ItemType"/> associated with the given item.</returns>
		public ItemUpdater CreateItemUpdater(Item item);
	}
}
