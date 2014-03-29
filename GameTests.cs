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
			var game = new Game();
			var evolvedUniverse = game.Evolve(universeWithNoLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}

		[Test]
		public void GivenAUniverseWithOneLiveCell_WhenEvolved_TheUniverseContainsNoLiveCells()
		{
			var liveCell = new Cell();
			var universeWithOneLiveCell = new Universe(new[] { liveCell });
			var game = new Game();
			var evolvedUniverse = game.Evolve(universeWithOneLiveCell);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}

		[Test]
		public void GivenAUniverseWithALiveCellWithTwoLiveNeighbours_WhenEvolved_TheCellIsStillAlive()
		{
			var liveCell = new Cell();
			var liveCellNeighbour1 = new Cell();
			var liveCellNeighbour2 = new Cell();
			var universeWithLiveCells = new Universe(new[] { liveCell, liveCellNeighbour1, liveCellNeighbour2 });
			var game = new Game();
			var evolvedUniverse = game.Evolve(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Contains.Item(liveCell));
		}

		[Test]
		public void GivenAUniverseWithOneLiveCellWithOneLiveNeighbour_WhenEvolved_TheCellDies()
		{
			var liveCell = new Cell();
			var liveNeighbour = new Cell();
			var universeWithLiveCells = new Universe(new[] {liveCell, liveNeighbour,});
			var game = new Game();
			var evolvedUniverse = game.Evolve(universeWithLiveCells);

			Assert.That(evolvedUniverse.LiveCells, Has.No.Member(liveCell));
		}
	}
}
