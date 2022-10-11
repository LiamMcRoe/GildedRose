using GildedRose.ItemUpdaters;
using GildedRose.Models;

namespace GildedRose.UnitTests.ItemUpdaters
{
	[TestClass]
	public class ItemUpdaterFactoryTests
	{
		[DataTestMethod]
		[DataRow("Standard Item Name", typeof(StandardItemUpdater))]
		[DataRow("Backstage passes to a TAFKAL80ETC concert", typeof(ConcertItemUpdater))]
		[DataRow("Aged Brie", typeof(BrieItemUpdater))]
		[DataRow("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemUpdater))]
		[DataRow("Conjured Mana Cake", typeof(ConjuredItemUpdater))]
		public void CreateItemUpdater_ItemTypes_Tests(string itemName, Type expectedItemUpdaterType)
		{
			var itemUpdaters = new Dictionary<ItemType, Func<Item, ItemUpdater>>
			{
				{ ItemType.Standard, item => new StandardItemUpdater(item) },
				{ ItemType.Legendary, item => new LegendaryItemUpdater(item) },
				{ ItemType.Concert, item => new ConcertItemUpdater(item) },
				{ ItemType.Brie, item => new BrieItemUpdater(item) },
				{ ItemType.Conjured, item => new ConjuredItemUpdater(item) }
			};

			var factory = new ItemUpdaterFactory(itemUpdaters);

			var item = new Item { Name = itemName };
			var itemUpdater = factory.CreateItemUpdater(item);
			Assert.IsInstanceOfType(itemUpdater, expectedItemUpdaterType);
		}

		[TestMethod]
		public void CreateItemUpdater_TypeNotRegistered_Test()
		{
			var itemUpdaters = new Dictionary<ItemType, Func<Item, ItemUpdater>>
			{
				{ ItemType.Legendary, item => new LegendaryItemUpdater(item) }
			};

			var factory = new ItemUpdaterFactory(itemUpdaters);

			var item = new Item { Name = "Standard item name" };
			Assert.ThrowsException<InvalidOperationException>(() => factory.CreateItemUpdater(item));
		}

		[TestMethod]
		public void CreateItemUpdater_ItemArgNull_Test()
		{
			var itemUpdaters = new Dictionary<ItemType, Func<Item, ItemUpdater>>
			{
				{ ItemType.Legendary, item => new LegendaryItemUpdater(item) }
			};

			var factory = new ItemUpdaterFactory(itemUpdaters);

			Assert.ThrowsException<ArgumentNullException>(() => factory.CreateItemUpdater(null));
		}
	}
}
