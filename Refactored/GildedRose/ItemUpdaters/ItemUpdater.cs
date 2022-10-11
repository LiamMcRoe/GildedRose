using GildedRose.Models;

namespace GildedRose.ItemUpdaters
{
	/// <summary>
	/// Base for classes that perform updates on <see cref="Item"/>s.
	/// </summary>
	public abstract class ItemUpdater
	{
		/// <summary>
		/// The <see cref="Item"/> to be updated.
		/// </summary>
		protected readonly Item item;

		/// <summary>
		/// Initializes a new instance of the <see cref="ItemUpdater"/> class.
		/// </summary>
		/// <param name="item">The <see cref="Item"/> to be updated.</param>
		public ItemUpdater(Item item)
		{
			this.item = item;
		}

		/// <summary>
		/// The maximum value that the wrapped <see cref="Item"/>'s quality can take.
		/// </summary>
		protected virtual int UpperQualityLimit => 50;

		/// <summary>
		/// The minimum value that the wrapped <see cref="Item"/>'s quality can take.
		/// </summary>
		protected virtual int LowerQualityLimit => 0;

		/// <summary>
		/// Performs an update on the item for a single day.
		/// </summary>
		public abstract void Update();

		/// <summary>
		/// Updates the wrapped <see cref="Item"/>'s SellIn property by decreasing its value by one.
		/// </summary>
		protected virtual void UpdateSellIn()
		{
			item.SellIn--;
		}

		/// <summary>
		/// Updates the wrapped <see cref="Item"/>'s Quality property by the given amount, within the upper and lower limits defined by <see cref="UpperQualityLimit"/> and <see cref="LowerQualityLimit"/>.
		/// </summary>
		/// <param name="updateAmount">The amount to update the quality by.</param>
		protected virtual void UpdateQuality(int updateAmount)
		{
			if (updateAmount == 0) return;
			else if (updateAmount > 0) IncreaseQuality(updateAmount);
			else DecreaseQuality(-updateAmount);
		}

		/// <summary>
		/// Increases the Quality of the wrapped item by the given amount, up to a maximum value of <see cref="UpperQualityLimit"/>.
		/// </summary>
		/// <param name="increaseBy">The amount for the item's Quality to be increased.</param>
		private void IncreaseQuality(int increaseBy)
		{
			while (increaseBy > 0)
			{
				if (item.Quality >= UpperQualityLimit) return;
				item.Quality++;
				increaseBy--;
			}
		}

		/// <summary>
		/// Decreases the Quality of the wrapped item by the given amount, down to a minimum value of <see cref="LowerQualityLimit"/>.
		/// </summary>
		/// <param name="decreaseBy">The amount for the item's Quality to be decreased.</param>
		private void DecreaseQuality(int decreaseBy)
		{
			while (decreaseBy > 0)
			{
				if (item.Quality <= LowerQualityLimit) return;
				item.Quality--;
				decreaseBy--;
			}
		}
	}
}
