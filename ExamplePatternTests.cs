using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class ExamplePatternTests
	{
		[Test]
		public void Blinker()
		{
			var game = new Game();
			var threeInARow = new[] { new Cell(0, 2), new Cell(1, 2), new Cell(2, 2) };
			var initialUniverse = new Universe(threeInARow);
			var evolvedUniverse = game.Evolve(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Is.EquivalentTo(new[] { new Cell(1, 1), new Cell(1, 2), new Cell(1, 3) }));
		}

		[Test]
		public void Block()
		{
			var game = new Game();
			var block = new[] { new Cell(1, 1), new Cell(2, 1), new Cell(1, 2), new Cell(2, 2) };
			var initialUniverse = new Universe(block);
			var evolvedUniverse = game.Evolve(initialUniverse);

			Assert.That(evolvedUniverse.LiveCells, Is.EquivalentTo(new[] {new Cell(1, 1), new Cell(2, 1), new Cell(1, 2), new Cell(2, 2)}));
		}
	}
}