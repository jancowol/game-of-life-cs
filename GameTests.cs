using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class GameTests
	{
		[Test]
		public void GivenAUniverseWithNoLiveCells_WhenEvolved_TheUniverseContainsNoLiveCells()
		{
			var universeWithNoLiveCells = new Universe(new ICell[0]);

			var evolvedUniverse = EvolveUniverse(universeWithNoLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		public void GivenAUniverseWithOneLiveCellAndLessThanTwoLiveNeighbours_WhenEvolved_TheCellDies(int liveNeighbourCount)
		{
			var liveCell = new FakeCell(liveNeighbourCount);
			var initialUniverse = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}

		[Test]
		[TestCase(2)]
		[TestCase(3)]
		public void GivenAUniverseWithALiveCellWithBetweenTwoAndThreeLiveNeighbours_WhenEvolved_TheCellIsStillAlive(int liveNeighbourCount)
		{
			var liveCell = new FakeCell(liveNeighbourCount);
			var initialUniverse = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Contains.Item(liveCell));
		}

		[Test]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		public void GivenAUniverseWithALiveCellWithMoreThanThreeLiveNeighbours_WhenEvolved_TheCellDies(int liveNeighbourCount)
		{
			var liveCell = new FakeCell(liveNeighbourCount);
			var initialUniverse = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}

		[Test]
		public void GivenAUniverseWithADeadCellWithThreeLiveNeighbours_WhenEvolved_TheCellComesAlive()
		{
			var deadCell = new FakeCell(liveNeighbourCount: 3);
			var liveCell1 = new FakeCell(deadCell);
			var liveCell2 = new FakeCell(deadCell);
			var liveCell3 = new FakeCell(deadCell);
			var initialUniverse = new Universe(new[]{liveCell1, liveCell2, liveCell3});

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Has.Member(deadCell));
		}

		private static IUniverse EvolveUniverse(IUniverse initialUniverse)
		{
			var game = new Game();
			return game.Evolve(initialUniverse);
		}
	}
}
