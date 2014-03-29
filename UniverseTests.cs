using System.Collections.Generic;
using System.Linq;
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

		[Test]
		// TODO: Possibly rename to DeadCellsAreTheSetOfAllNonAliveCellsNeighbouringAnyLiveCells to clarify what's happening
		public void DeadCellsAreTheSetOfAllDeadCellsNeighbouringAnyLiveCells()
		{
			var adjacentDeadCell1 = new FakeCell();
			var adjacentDeadCell2 = new FakeCell();
			var liveCell = new FakeCell(adjacentDeadCell1, adjacentDeadCell2);
			var universe = new Universe(new[] { liveCell });

			Assert.That(universe.DeadCells, Is.EquivalentTo(new[] { adjacentDeadCell1, adjacentDeadCell2 }));
		}
	}

	public class Universe : IUniverse
	{
		public Universe()
			: this(new ICell[0])
		{
		}

		public Universe(IEnumerable<ICell> liveCells)
		{
			LiveCells = liveCells;
		}

		public IEnumerable<ICell> LiveCells { get; private set; }

		public IEnumerable<ICell> DeadCells
		{
			get { return LiveCells.SelectMany(liveCell => liveCell.AdjacentCells()); }
		}

	}
}