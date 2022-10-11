using GildedRose.Models;

namespace GildedRose.ItemUpdaters
{
    /// <summary>
    /// Performs updates on an <see cref="Item"/> of type <see cref="ItemType.Concert"/>.
    /// </summary>
    public class ConcertItemUpdater : ItemUpdater
    {
        /// <summary>
		/// Initializes a new instance of the <see cref="ConcertItemUpdater"/> class.
		/// </summary>
		/// <param name="item">The <see cref="Item"/> to be updated.</param>
		public ConcertItemUpdater(Item item) : base(item) { }

        /// <summary>
		/// Performs an update on the item for a single day.
		/// </summary>
		public override void Update()
        {
            UpdateSellIn();
            if (item.SellIn < 0)
            { 
                item.Quality = 0;
                return;
            }

            int updateQualityAmount;
            if (item.SellIn < 5) updateQualityAmount = 3;
            else if (item.SellIn < 10) updateQualityAmount = 2;
            else updateQualityAmount = 1;
            UpdateQuality(updateQualityAmount);
        }
    }
}