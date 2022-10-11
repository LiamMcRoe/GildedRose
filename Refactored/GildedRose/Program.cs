using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using GildedRose;
using GildedRose.ItemUpdaters;
using GildedRose.Models;

using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((_, services) =>
		services
		.AddSingleton<Inventory>()
		.AddTransient<IItemUpdaterFactory, ItemUpdaterFactory>(
			x => new ItemUpdaterFactory(new Dictionary<ItemType, Func<Item, ItemUpdater>>
			{
				{ ItemType.Standard, item => new StandardItemUpdater(item) },
				{ ItemType.Legendary, item => new LegendaryItemUpdater(item) },
				{ ItemType.Concert, item => new ConcertItemUpdater(item) },
				{ ItemType.Brie, item => new BrieItemUpdater(item) },
				{ ItemType.Conjured, item => new ConjuredItemUpdater(item) }
			}))
		.AddTransient<IGildedRose, GildedRose.GildedRose>()
		.AddTransient<IApplication, Application>())
	.Build();

var application = host.Services.GetRequiredService<IApplication>();
application.Run(numberOfDays: 31);
