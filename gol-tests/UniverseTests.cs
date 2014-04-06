using NUnit.Framework;
using gol;

namespace gol_tests
{
	[TestFixture]
	public class UniverseTests
	{
		//[Test]
		//public void DeadCellsAreTheSetOfAllDeadCellsNeighbouringAnyLiveCells()
		//{
		//	var adjacentDeadCell1 = new FakeCellLocation();
		//	var adjacentDeadCell2 = new FakeCellLocation();
		//	var liveCell1 = new FakeCellLocation(adjacentDeadCell1, adjacentDeadCell2);

		//	var adjacentDeadCell3 = new FakeCellLocation();
		//	var adjacentDeadCell4 = new FakeCellLocation();
		//	var liveCell2 = new FakeCellLocation(adjacentDeadCell3, adjacentDeadCell4);

		//	var universe = new Universe(new[] { liveCell1, liveCell2 });

		//	Assert.That(universe.DeadCellLocations,
		//		Is.SubsetOf(new[] { adjacentDeadCell1, adjacentDeadCell2, adjacentDeadCell3, adjacentDeadCell4 }));
		//}

		//[Test]
		//public void TheSetOfDeadCellsMustBeUnique()
		//{
		//	var adjacentDeadCell = new FakeCellLocation();
		//	var liveCell1 = new FakeCellLocation(adjacentDeadCell);
		//	var liveCell2 = new FakeCellLocation(adjacentDeadCell);
		//	var universe = new Universe(new[] { liveCell1, liveCell2 });

		//	Assert.That(universe.DeadCellLocations, Is.Unique);
		//}

		//[Test]
		//public void TheSetOfDeadCellsCannotContainLiveCells()
		//{
		//	var liveCell1 = new FakeCellLocation(fakeNeighbours: new ICellLocation[0]);
		//	var liveCell2 = new FakeCellLocation(liveCell1);
		//	var universe = new Universe(new[] { liveCell1, liveCell2 });

		//	Assert.That(universe.DeadCellLocations, Has.No.Member(liveCell1));
		//	Assert.That(universe.DeadCellLocations, Has.No.Member(liveCell2));
		//}
	}
}