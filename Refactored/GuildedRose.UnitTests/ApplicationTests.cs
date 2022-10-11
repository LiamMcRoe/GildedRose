using GildedRose.Models;
using Moq;

namespace GildedRose.UnitTests
{
	[TestClass]
    public class ApplicationTests
    {
        private Mock<IGildedRose> mockGildedRose;
        private Inventory inventory;

        [TestInitialize]
        public void TestInitialize()
        {
            mockGildedRose = new Mock<IGildedRose>();
            inventory = new Inventory();
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-10)]
        [DataRow(-999)]
        [DataRow(int.MinValue)]
        public void Run_ThrowsException_IfNumberOfDaysNegative_Test(int numberOfDays)
        {
            var application = new Application(mockGildedRose.Object, inventory);
            Assert.ThrowsException<InvalidOperationException>(() => application.Run(numberOfDays));
        }

		[DataTestMethod]
		[DataRow(0)]
		[DataRow(1)]
		[DataRow(10)]
		[DataRow(999)]
        public void Run_IteratesGildedRose_ForGivenNumberOfDays_Test(int numberOfDays)
        {
            var application = new Application(mockGildedRose.Object, inventory);
            application.Run(numberOfDays);
            mockGildedRose.Verify(x => x.UpdateQuality(), Times.Exactly(numberOfDays));
        }
    }
}
