using NUnit.Framework;

[TestFixture]
public class GameTests
{
	[Test]
	public void GivenAUniverseWithNoLivingCells_WhenEvolved_TheUniverseContainsNoLivingCells()
	{
		var emptyUniverse = new Universe();
		var game = new Game();
		var evolvedUniverse = game.Evolve(emptyUniverse);

		Assert.That(evolvedUniverse.LiveCells, Is.Empty);
	}
}

public class Game
{
	public Universe Evolve(Universe universe)
	{
		return new Universe();
	}
}

public class Universe
{
	public object[] LiveCells { get; set; }

	public Universe()
	{
		LiveCells = new object[0];
	}
}