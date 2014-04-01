using System.Linq;
using NUnit.Framework;
using gol;

namespace gol_tests
{
	[TestFixture]
	public class GameTests
	{
		[Test]
		public void GivenAUniverseWithNoLiveCells_WhenEvolved_TheUniverseContainsNoLiveCells()
		{
			var universeWithNoLiveCells = new Universe(new ICellLocation[0]);

			var evolvedUniverse = EvolveUniverse(universeWithNoLiveCells);

			Assert.That(evolvedUniverse.LiveCellLocations, Is.Empty);
		}

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		public void GivenAUniverseWithOneLiveCellAndLessThanTwoLiveNeighbours_WhenEvolved_TheCellDies(int liveNeighbourCount)
		{
			var liveNeighbours = CreateCells(liveNeighbourCount);
			var liveCell = new FakeCellLocation(liveNeighbours);
			var allLiveCells = liveNeighbours.Concat(new[] { liveCell });
			var initialUniverse = new Universe(allLiveCells);

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCellLocations, Has.No.Member(liveCell));
		}

		[Test]
		[TestCase(2)]
		[TestCase(3)]
		public void GivenAUniverseWithALiveCellWithBetweenTwoAndThreeLiveNeighbours_WhenEvolved_TheCellIsStillAlive(int liveNeighbourCount)
		{
			var liveNeighbours = CreateCells(liveNeighbourCount);
			var liveCell = new FakeCellLocation(liveNeighbours);
			var allLiveCells = liveNeighbours.Concat(new[] { liveCell });
			var initialUniverse = new Universe(allLiveCells);

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCellLocations, Contains.Item(liveCell));
		}

		[Test]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		public void GivenAUniverseWithALiveCellWithMoreThanThreeLiveNeighbours_WhenEvolved_TheCellDies(int liveNeighbourCount)
		{
			var liveNeighbours = CreateCells(liveNeighbourCount);
			var liveCell = new FakeCellLocation(liveNeighbours);
			var allLiveCells = liveNeighbours.Concat(new[] { liveCell });
			var initialUniverse = new Universe(allLiveCells);

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCellLocations, Has.No.Member(liveCell));
		}

		[Test]
		public void GivenAUniverseWithADeadCellWithThreeLiveNeighbours_WhenEvolved_TheCellComesAlive()
		{
			var deadCell = new FakeCellLocation();
			var liveCell1 = new FakeCellLocation(deadCell);
			var liveCell2 = new FakeCellLocation(deadCell);
			var liveCell3 = new FakeCellLocation(deadCell);
			deadCell.SetFakeNeighbours(new[] { liveCell1, liveCell2, liveCell3 });
			var initialUniverse = new Universe(new[] { liveCell1, liveCell2, liveCell3 });

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCellLocations, Has.Member(deadCell));
		}

		private static IUniverse EvolveUniverse(IUniverse initialUniverse)
		{
			var game = new Game();
			return game.Tick(initialUniverse);
		}

		private static FakeCellLocation[] CreateCells(int liveNeighbourCount)
		{
			return Enumerable.Range(1, liveNeighbourCount)
							.Select(x => new FakeCellLocation()).ToArray();
		}
	}
}
