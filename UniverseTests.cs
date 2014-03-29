using NUnit.Framework;
using gol;

[TestFixture]
public class UniverseTests
{
	[Test]
	public void NewUniverseDoesNotContainAnyLiveCells()
	{
		var universe = new Universe();
		Assert.That(universe.LiveCells, Is.Empty);
	}
}