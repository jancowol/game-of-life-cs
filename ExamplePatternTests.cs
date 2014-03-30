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
			Cells(
				"XX",
				"XX")
			.TransformsTo(
				"XX",
				"XX");
		}

		[Test]
		public void Toad()
		{
			Cells(
				"    ",
				" XXX",
				"XXX")
			.TransformsTo(
				"  X",
				"X  X",
				"X  X",
				" X");
		}
		private static IEnumerable<ICell> Cells(params string[] pattern)
		{
			return PatternTestExtensions.Cells(pattern);
		}
	}
}