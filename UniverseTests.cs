using NUnit.Framework;
using gol;

[TestFixture]
public class UniverseTests
{
	[Test]
	public void NewUniverseDoesNotContainAnyLiveCells()
	{
		var universe = new FakeUniverse();
		Assert.That(universe.LiveCells, Is.Empty);
	}
}