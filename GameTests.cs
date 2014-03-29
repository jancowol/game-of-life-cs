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
			var universeWithOneLiveCell = new Universe(liveCell);
			var game = new Game();
			var evolvedUniverse = game.Evolve(universeWithOneLiveCell);

			Assert.That(evolvedUniverse.LiveCells, Is.Empty);
		}
	}
}
