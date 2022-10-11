using GildedRose.ItemUpdaters;
using GildedRose.Models;

namespace GildedRose
{
	/// <summary>
	/// Manages the <see cref="Inventory"/> of the Gilded Rose shop.
	/// </summary>
	public class GildedRose : IGildedRose
    {
        private readonly Inventory inventory;
        private readonly IItemUpdaterFactory updaterFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GildedRose"/> class.
        /// </summary>
        /// <param name="updaterFactory">Factory for the creation of <see cref="ItemUpdater"/>s.</param>
        /// <param name="inventory">The <see cref="Inventory"/> of the gilded rose shop.</param>
        public GildedRose(IItemUpdaterFactory updaterFactory, Inventory inventory)
        {
            this.inventory = inventory;
            this.updaterFactory = updaterFactory;
        }

        /// <summary>
        /// Gets the <see cref="Item"/>s in the <see cref="inventory"/>.
        /// </summary>
        public IList<Item> Items => inventory.Items;

        /// <summary>
        /// Performs updates on the <see cref="inventory"/> for a single day.
        /// </summary>
        public void UpdateQuality()
        {
            foreach (var item in inventory.Items)
            {
                this.updaterFactory.CreateItemUpdater(item).Update();
            }
        }
    }
}
