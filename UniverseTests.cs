using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class UniverseTests
	{
		[Test]
		public void DeadCellsAreTheSetOfAllDeadCellsNeighbouringAnyLiveCells()
		{
			var adjacentDeadCell1 = new FakeCell();
			var adjacentDeadCell2 = new FakeCell();
			var liveCell1 = new FakeCell(adjacentDeadCell1, adjacentDeadCell2);

			var adjacentDeadCell3 = new FakeCell();
			var adjacentDeadCell4 = new FakeCell();
			var liveCell2 = new FakeCell(adjacentDeadCell3, adjacentDeadCell4);

			var universe = new Universe(new[] { liveCell1, liveCell2 });

			Assert.That(universe.DeadCells,
				Is.SubsetOf(new[] { adjacentDeadCell1, adjacentDeadCell2, adjacentDeadCell3, adjacentDeadCell4 }));
		}

		[Test]
		public void TheSetOfDeadCellsMustBeUnique()
		{
			var adjacentDeadCell = new FakeCell();
			var liveCell1 = new FakeCell(adjacentDeadCell);
			var liveCell2 = new FakeCell(adjacentDeadCell);
			var universe = new Universe(new[] { liveCell1, liveCell2 });

			Assert.That(universe.DeadCells, Is.Unique);
		}

		[Test]
		public void TheSetOfDeadCellsCannotContainLiveCells()
		{
			var liveCell1 = new FakeCell(adjacentCells: new ICell[0]);
			var liveCell2 = new FakeCell(liveCell1);
			var universe = new Universe(new[] { liveCell1, liveCell2 });

			Assert.That(universe.DeadCells, Has.No.Member(liveCell1));
			Assert.That(universe.DeadCells, Has.No.Member(liveCell2));
		}
	}
}