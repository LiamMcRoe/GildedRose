using GildedRose.Models;

namespace GildedRose.ItemUpdaters
{
	/// <summary>
	/// Performs updates on an <see cref="Item"/> of type <see cref="ItemType.Legendary"/>.
	/// </summary>
	public class LegendaryItemUpdater : ItemUpdater
	{
		private const int fixedQuality = 80;

		/// <summary>
		/// Initializes a new instance of the <see cref="LegendaryItemUpdater"/> class.
		/// </summary>
		/// <param name="item">The <see cref="Item"/> to be updated.</param>
		public LegendaryItemUpdater(Item item) : base(item) { }

		/// <summary>
		/// The maximum value that the wrapped <see cref="Item"/>'s quality can take.
		/// </summary>
		protected override int UpperQualityLimit => fixedQuality;

		/// <summary>
		/// The minimum value that the wrapped <see cref="Item"/>'s quality can take.
		/// </summary>
		protected override int LowerQualityLimit => fixedQuality;

		/// <summary>
		/// Performs an update on the item for a single day.
		/// </summary>
		public override void Update()
		{
			// Legendary items never have to be sold or decrease in quality, so just return.
			return;
		}

		/// <summary>
		/// Has no effect for this type of <see cref="Item"/>.
		/// </summary>
		protected override void UpdateSellIn()
		{
			// Legendary items never degrade, so override UpdateSellIn to ensure item.SellIn never decremented.
			return;
		}

		/// <summary>
		/// Has no effect for this type of <see cref="Item"/>.
		/// </summary>
		protected override void UpdateQuality(int updateAmount)
		{
			// Legendary items never degrade, so override UpdateQuality to ensure item.Quality never altered.
			return;
		}
	}
}
