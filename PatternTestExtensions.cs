using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace gol
{
	public static class PatternTestExtensions
	{
		public static void TransformsTo(this IEnumerable<ICell> initial, params string[] expectedPattern)
		{
			var evolvedUniverse = Evolve(initial);
			var expected = Cells(expectedPattern);
			Assert.That(evolvedUniverse.LiveCells, Is.EquivalentTo(expected));
		}

		public static IUniverse Evolve(IEnumerable<ICell> threeInARow)
		{
			var game = new Game();
			var initialUniverse = new Universe(threeInARow.ToArray());
			return game.Evolve(initialUniverse);
		}

		public static IEnumerable<ICell> Cells(params string[] pattern)
		{
			for (int y = 0; y < pattern.Length; y++)
			{
				var line = pattern[y];
				for (int x = 0; x < line.Length; x++)
					if (line[x] == 'X')
						yield return new Cell(x, y);
			}
		}
	}
}