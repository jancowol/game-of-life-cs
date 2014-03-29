using System.Collections.Generic;
using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class UniverseTests
	{
		[Test]
		public void NewUniverseDoesNotContainAnyLiveCells()
		{
			var universe = new Universe();
			Assert.That(universe.LiveCells, Is.Empty);
		}
	}

	public class Universe : IUniverse
	{
		public IEnumerable<ICell> LiveCells { get; private set; }
		public IEnumerable<ICell> DeadCells { get; set; }

		public Universe() : this(new ICell[0])
		{
		}

		public Universe(IEnumerable<ICell> liveCells)
		{
			LiveCells = liveCells;
			DeadCells = new ICell[0];
		}

		public Universe(IEnumerable<ICell> liveCells, IEnumerable<ICell> deadCells)
		{
			LiveCells = liveCells;
			DeadCells = deadCells;
		}
	}
}