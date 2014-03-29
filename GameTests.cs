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
		public void GivenAUniverseWithOneLiveCell_WhenEvolved_TheUniverseContainsNoLiveCells()
		{
			var liveCell = new FakeCell(liveNeighbourCount: 0);
			var universeWithOneLiveCell = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(universeWithOneLiveCell);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}

		[Test]
		public void GivenAUniverseWithALiveCellWithTwoLiveNeighbours_WhenEvolved_TheCellIsStillAlive()
		{
			var liveCell = new FakeCell(liveNeighbourCount: 2);
			var universeWithLiveCells = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Contains.Item(liveCell));
		}

		[Test]
		public void GivenAUniverseWithALiveCellWithThreeLiveNeighbours_WhenEvolved_TheCellIsStillAlive()
		{
			var liveCell = new FakeCell(liveNeighbourCount: 3);
			var universeWithLiveCells = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Contains.Item(liveCell));
		}

		[Test]
		public void GivenAUniverseWithOneLiveCellWithOneLiveNeighbour_WhenEvolved_TheCellDies()
		{
			var liveCell = new FakeCell(liveNeighbourCount: 0);
			var universeWithLiveCells = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}

		[Test]
		public void GivenAUniverseWithThreeLiveCellsWhichAreNotNeighbours_WhenEvolved_AllThreeDies()
		{
			var liveCell1 = new FakeCell(liveNeighbourCount: 0);
			var liveCell2 = new FakeCell(liveNeighbourCount: 0);
			var liveCell3 = new FakeCell(liveNeighbourCount: 0);
			var universeWithLiveCells = new Universe(new[] { liveCell1, liveCell2, liveCell3 });

			var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}

		[Test]
		public void GivenALiveCellWithFourLiveNeighbours_WhenEvolved_TheCellDies()
		{
			var liveCell = new FakeCell(liveNeighbourCount: 4);
			var universeWithLiveCells = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}

		private static Universe EvolveUniverse(Universe initialUniverse)
		{
			var game = new Game();
			return game.Evolve(initialUniverse);
		}
	}
}
