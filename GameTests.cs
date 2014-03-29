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
			var liveCell = new FakeCell();
			var universeWithOneLiveCell = new Universe(new[] { liveCell });

			var evolvedUniverse = EvolveUniverse(universeWithOneLiveCell);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}

		[Test]
		public void GivenAUniverseWithALiveCellWithTwoLiveNeighbours_WhenEvolved_TheCellIsStillAlive()
		{
			var liveCellNeighbour1 = new FakeCell();
			var liveCellNeighbour2 = new FakeCell();
			var liveCell = new FakeCell(liveCellNeighbour1, liveCellNeighbour2);
			var universeWithLiveCells = new Universe(new[] { liveCell, liveCellNeighbour1, liveCellNeighbour2 });

			var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Contains.Item(liveCell));
		}

		[Test]
		public void GivenAUniverseWithOneLiveCellWithOneLiveNeighbour_WhenEvolved_TheCellDies()
		{
			var liveNeighbour = new FakeCell();
			var liveCell = new FakeCell(liveNeighbour);
			var universeWithLiveCells = new Universe(new[] { liveCell, liveNeighbour, });

			var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}

		//[Test]
		//public void GivenAUniverseWithThreeLiveCellsWhichAreNotNeighbours_WhenEvolved_AllThreeDies()
		//{
		//	var liveCell1 = new FakeCell();
		//	var liveCell2 = new FakeCell();
		//	var liveCell3 = new FakeCell();
		//	var universeWithLiveCells = new Universe(new[] {liveCell1, liveCell2, liveCell3});

		//	var evolvedUniverse = EvolveUniverse(universeWithLiveCells);

		//	Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		//}

		private static Universe EvolveUniverse(Universe initialUniverse)
		{
			var game = new Game();
			return game.Evolve(initialUniverse);
		}
	}
}
