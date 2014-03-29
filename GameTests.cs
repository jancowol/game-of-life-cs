using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class GameTests
	{
		[Test]
		public void GivenAUniverseWithNoLiveCells_WhenEvolved_TheUniverseContainsNoLiveCells()
		{
			var universeWithNoLiveCells = new FakeUniverse();

			var evolvedUniverse = EvolveUniverse(universeWithNoLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		public void GivenAUniverseWithOneLiveCellAndLessThanTwoLiveNeighbours_WhenEvolved_TheCellDies(int liveNeighbourCount)
		{
			var liveCell = new FakeCell(liveNeighbourCount);
			var initialUniverse = new FakeUniverse(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}

		[Test]
		[TestCase(2)]
		[TestCase(3)]
		public void GivenAUniverseWithALiveCellWithBetweenTwoAndThreeLiveNeighbours_WhenEvolved_TheCellIsStillAlive(int liveNeighbourCount)
		{
			var liveCell = new FakeCell(liveNeighbourCount);
			var initialUniverse = new FakeUniverse(new[] { liveCell });

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
			var initialUniverse = new FakeUniverse(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}

		[Test]
		public void GivenAUniverseWithADeadCellWithThreeLiveNeighbours_WhenEvolved_TheCellComesAlive()
		{
			var deadCell = new FakeCell(liveNeighbourCount: 3);
			var initialUniverse = new FakeUniverse(new ICell[0], new ICell[] { deadCell });

			var evolvedUniverse = EvolveUniverse(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Has.Member(deadCell));
		}

		private static IUniverse EvolveUniverse(FakeUniverse initialUniverse)
		{
			var game = new Game();
			return game.Evolve(initialUniverse);
		}
	}
}
