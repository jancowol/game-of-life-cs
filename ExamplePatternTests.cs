using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class ExamplePatternTests
	{
		[Test]
		public void Blinker()
		{
			var evolvedUniverse = Evolve(CellsFor(
				"   ",
				"XXX"));

			var expected = CellsFor(
				" X ",
				" X ",
				" X ");

			Assert.That(evolvedUniverse.LiveCells, Is.EquivalentTo(expected));
		}

		[Test]
		public void Block()
		{
			var block = new[] { new Cell(1, 1), new Cell(2, 1), new Cell(1, 2), new Cell(2, 2) };

			var evolvedUniverse = Evolve(block);

			Assert.That(evolvedUniverse.LiveCells, Is.EquivalentTo(new[] {new Cell(1, 1), new Cell(2, 1), new Cell(1, 2), new Cell(2, 2)}));
		}

		private static IEnumerable<ICell> CellsFor(params string[] pattern)
		{
			for (int y = 0; y < pattern.Length; y++)
			{
				var line = pattern[y];
				for (int x = 0; x < line.Length; x++)
				{
					if (line[x] == 'X')
					{
						yield return new Cell(x, y);
					}
				}
			}
		}

		private static IUniverse Evolve(IEnumerable<ICell> threeInARow)
		{
			var game = new Game();
			var initialUniverse = new Universe(threeInARow.ToArray());
			return game.Evolve(initialUniverse);
		}
	}
}