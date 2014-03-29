using NUnit.Framework;

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
}