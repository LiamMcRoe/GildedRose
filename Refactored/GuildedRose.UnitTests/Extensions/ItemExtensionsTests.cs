using GildedRose.Extensions;
using GildedRose.Models;

namespace GildedRose.UnitTests.Extensions
{
	[TestClass]
	public class ItemExtensionsTests
	{
		[DataTestMethod]
		[DataRow("Sulfuras, Hand of Ragnaros", ItemType.Legendary)]
		[DataRow("Aged Brie", ItemType.Brie)]
		[DataRow("Backstage passes to a TAFKAL80ETC concert", ItemType.Concert)]
		[DataRow("Conjured Mana Cake", ItemType.Conjured)]
		[DataRow("Some other string", ItemType.Standard)]
		public void GetItemType_Tests(string itemName, ItemType expectedItemType)
		{
			var item = new Item { Name = itemName };
			Assert.AreEqual(expectedItemType, item.GetItemType());
		}
	}
}
