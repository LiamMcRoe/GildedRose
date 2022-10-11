using GildedRose.Extensions;
using GildedRose.Models;

namespace GildedRose.ItemUpdaters
{
	/// <summary>
	/// Implements a factory for the creation of <see cref="ItemUpdater"/> classes.
	/// </summary>
	public class ItemUpdaterFactory : IItemUpdaterFactory
	{
		private readonly IDictionary<ItemType, Func<Item, ItemUpdater>> itemUpdaterConstructors;

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemUpdaterFactory"/> class.
		/// </summary>
		/// <param name="itemUpdaters">A dictionary that links <see cref="ItemType"/>s to functions that create instances of <see cref="ItemUpdater"/>.</param>
		public ItemUpdaterFactory(IDictionary<ItemType, Func<Item, ItemUpdater>> itemUpdaters)
		{
			this.itemUpdaterConstructors = itemUpdaters;
		}

		/// <summary>
		/// Creates an instance of <see cref="ItemUpdater"/> based on the <see cref="ItemType"/> associated with the given item.
		/// </summary>
		/// <param name="item">The <see cref="Item"/> for which to create the <see cref="ItemUpdater"/>.</param>
		/// <returns>An instance of an <see cref="ItemUpdater"/> implementation based on the <see cref="ItemType"/> associated with the given item.</returns>
		public ItemUpdater CreateItemUpdater(Item item)
		{
			ArgumentNullException.ThrowIfNull(item);
			var itemType = item.GetItemType();

			if (itemUpdaterConstructors.TryGetValue(itemType, out var itemUpdater)) return itemUpdater(item);

			throw new InvalidOperationException($"The type {itemType} is not regisitered with the factory.");
		}
	}
}
