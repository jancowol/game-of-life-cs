using System.Collections.Generic;
using NUnit.Framework;

namespace gol
{
	[TestFixture]
	public class ExamplePatternTests
	{
		[Test]
		public void Blinker()
		{
			Cells(
				"   ",
				"XXX")
			.TransformsTo(
				" X ",
				" X ",
				" X ");
		}

		[Test]
		public void Block()
		{
			var block = new[] { new Cell(1, 1), new Cell(2, 1), new Cell(1, 2), new Cell(2, 2) };

			var evolvedUniverse = PatternTestExtensions.Evolve(block);

			Assert.That(evolvedUniverse.LiveCells, Is.EquivalentTo(new[] {new Cell(1, 1), new Cell(2, 1), new Cell(1, 2), new Cell(2, 2)}));
		}

		private static IEnumerable<ICell> Cells(params string[] pattern)
		{
			return PatternTestExtensions.Cells(pattern);
		}
	}
}