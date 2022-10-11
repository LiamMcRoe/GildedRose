using GildedRose.ItemUpdaters;
using GildedRose.Models;
using Moq;

namespace GildedRose.UnitTests
{
	[TestClass]
	public class GildedRoseTests
	{

        private Mock<ItemUpdater> mockUpdater;
        private Mock<IItemUpdaterFactory> mockFactory;
        private Inventory inventory;
        private GildedRose gildedRose;

        [TestInitialize]
        public void TestInitialize() 
        { 
            mockUpdater = new Mock<ItemUpdater>(new Item());
            mockFactory = new Mock<IItemUpdaterFactory>();
            mockFactory.Setup(x => x.CreateItemUpdater(It.IsAny<Item>())).Returns(mockUpdater.Object);
            inventory = new Inventory();
            gildedRose = new GildedRose(mockFactory.Object, inventory);
        }

        [TestMethod]
        public void UpdateQuality_CallsItemUpdater_ForEachItem_Test()
        {
            inventory.Items = new List<Item>
            {
                new Item { Name = "Item1" },
                new Item { Name = "Item2" },
                new Item { Name = "Item3" }
            };

            gildedRose.UpdateQuality();

            mockUpdater.Verify(x => x.Update(), Times.Exactly(inventory.Items.Count));
        }

        [TestMethod]
        public void UpdateQuality_ItemsProperty_Test()
        {
            inventory.Items = new List<Item>
            {
                new Item { Name = "Item1" },
                new Item { Name = "Item2" },
                new Item { Name = "Item3" }
            };

            var items = gildedRose.Items;

            Assert.AreEqual(inventory.Items.Count, items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(inventory.Items[i], items[i]);
            }
        }
    }
}
