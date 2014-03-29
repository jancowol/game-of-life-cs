using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class GameTests
	{
		[Test]
		public void GivenAUniverseWithNoLiveCells_WhenEvolved_TheUniverseContainsNoLiveCells()
		{
			var universeWithNoLiveCells = new Universe();

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

		private static Universe EvolveUniverse(Universe initialUniverse)
		{
			var game = new Game();
			return game.Evolve(initialUniverse);
		}
	}
}
