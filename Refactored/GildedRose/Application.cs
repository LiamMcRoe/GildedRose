using GildedRose.Models;

namespace GildedRose
{
	/// <summary>
	/// Encapsulates the main application execution.
	/// </summary>
	public class Application : IApplication
	{
		private readonly IGildedRose gildedRose;
		private readonly Inventory inventory;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Application"/> class.
		/// </summary>
		/// <param name="gildedRose"></param>
		/// <param name="inventory">The inventory of <see cref="Item"/>s to be processed by the application.</param>
		public Application(IGildedRose gildedRose, Inventory inventory)
		{
			this.gildedRose = gildedRose;
			this.inventory = inventory;
		}

		/// <summary>
		/// Runs the main application, iterating over the given number of days.
		/// </summary>
		/// <param name="numberOfDays">The number of days to model.</param>
		public void Run(int numberOfDays)
		{
			if (numberOfDays < 0) throw new InvalidOperationException($"{nameof(numberOfDays)} must be greater than or equal to zero.");
			Console.WriteLine("OMGHAI!");
			for (var i = 0; i < numberOfDays; i++)
			{
				Console.WriteLine("-------- day " + i + " --------");
				Console.WriteLine("name, sellIn, quality");
				foreach(var item in inventory.Items)
				{
					System.Console.WriteLine(item);
				}
				Console.WriteLine();
				gildedRose.UpdateQuality();
			}
		}
	}
}
