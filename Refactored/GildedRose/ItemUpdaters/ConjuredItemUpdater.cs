using GildedRose.Models;

namespace GildedRose.ItemUpdaters
{
	/// <summary>
	/// Performs updates on an <see cref="Item"/> of type <see cref="ItemType.Conjured"/>.
	/// </summary>
	public class ConjuredItemUpdater : ItemUpdater
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemUpdater"/> class.
		/// </summary>
		/// <param name="item">The <see cref="Item"/> to be updated.</param>
		public ConjuredItemUpdater(Item item) : base(item) { }

		/// <summary>
		/// Performs an update on the item for a single day.
		/// </summary>
		public override void Update()
		{
			UpdateSellIn();
			int updateQualityAmount;
			if (item.SellIn < 0) updateQualityAmount = -4;
			else updateQualityAmount = -2;
			UpdateQuality(updateQualityAmount);
		}
	}
}
