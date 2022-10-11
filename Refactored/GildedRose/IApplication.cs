namespace GildedRose
{
	/// <summary>
	/// Encapsulates the main application execution.
	/// </summary>
	public interface IApplication
	{
		/// <summary>
		/// Runs the main application, iterating for the given number of days.
		/// </summary>
		/// <param name="numberOfDays">The number of days to model.</param>
		void Run(int numberOfDays);
	}
}