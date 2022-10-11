using GildedRose.ItemUpdaters;
using GildedRose.Models;

namespace GildedRose.UnitTests.ItemUpdaters
{
    [TestClass]
    public class ItemUpdaterTests
    {
        [DataTestMethod]
        [DataRow(1, 2, 10, 9)]
        [DataRow(49, 50, -1, -2)]
        [DataRow(50, 50, -1, -2)]
        [DataRow(50, 50, 2, 1)]
        [DataRow(0, 1, 2, 1)]
        public void BrieItemUpdater_Update_Tests(int startingQuality, int expectedQuality, int startingSellIn, int expectedSellIn)
        {
            var item = new Item { Name = "Aged Brie", Quality = startingQuality, SellIn = startingSellIn };
            var updater = new BrieItemUpdater(item);
            ExecuteUpdateTest(item, updater, expectedQuality, expectedSellIn);
        }

        [DataTestMethod]
        [DataRow(2, 1, 10, 9)]
        [DataRow(1, 0, -1, -2)]
        [DataRow(0, 0, -1, -2)]
        [DataRow(0, 0, 2, 1)]
        public void StandardItemUpdater_Update_Tests(int startingQuality, int expectedQuality, int startingSellIn, int expectedSellIn)
        {
            var item = new Item { Name = "Some Standard Item", Quality = startingQuality, SellIn = startingSellIn };
            var updater = new StandardItemUpdater(item);
            ExecuteUpdateTest(item, updater, expectedQuality, expectedSellIn);
        }

        [DataTestMethod]
        [DataRow(80, 80, 1, 1)]
        [DataRow(80, 80, -1, -1)]
        public void LegendaryItemUpdater_Update_Tests(int startingQuality, int expectedQuality, int startingSellIn, int expectedSellIn)
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = startingQuality, SellIn = startingSellIn };
            var updater = new LegendaryItemUpdater(item);
            ExecuteUpdateTest(item, updater, expectedQuality, expectedSellIn);
        }

        [DataTestMethod]
        [DataRow(10, 0, 0, -1)]
        [DataRow(0, 0, -1, -2)]
        [DataRow(10, 13, 5, 4)]
        [DataRow(10, 12, 6, 5)]
        [DataRow(10, 12, 10, 9)]
        [DataRow(10, 11, 11, 10)]
		[DataRow(48, 50, 3, 2)]
		[DataRow(49, 50, 7, 6)]
        public void ConcertItemUpdater_Update_Tests(int startingQuality, int expectedQuality, int startingSellIn, int expectedSellIn)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = startingQuality, SellIn = startingSellIn };
            var updater = new ConcertItemUpdater(item);
            ExecuteUpdateTest(item, updater, expectedQuality, expectedSellIn);
        }

        [DataTestMethod]
        [DataRow(-1, -1, 1, 0)]
        [DataRow(3, 0, 0, -1)]
        [DataRow(5, 1, -1, -2)]
        [DataRow(1, 0, -10, -11)]
        [DataRow(15, 13, 10, 9)]
        [DataRow(0, 0, 10, 9)]
        [DataRow(0, 0, -13, -14)]
        public void ConjuredItemUpdater_Update_Tests(int startingQuality, int expectedQuality, int startingSellIn, int expectedSellIn)
        {
            var item = new Item { Name = "Conjured Mana Cake", Quality = startingQuality, SellIn = startingSellIn };
            var updater = new ConjuredItemUpdater(item);
            ExecuteUpdateTest(item, updater, expectedQuality, expectedSellIn);
        }

        private void ExecuteUpdateTest(Item item, ItemUpdater itemUpdater, int expectedQuality, int expectedSellIn)
        {
            itemUpdater.Update();
            Assert.AreEqual(expectedQuality, item.Quality);
            Assert.AreEqual(expectedSellIn, item.SellIn);
        }
    }
}
