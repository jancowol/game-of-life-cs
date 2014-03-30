using System.Collections.Generic;
using NUnit.Framework;
using gol;

namespace gol_tests
{
	[TestFixture]
	public class ExamplePatternTests
	{
		[Test]
		public void Blinker()
		{
			Verify(
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
			Verify(
				"XX",
				"XX")
			.TransformsTo(
				"XX",
				"XX");
		}

		[Test]
		public void Toad()
		{
			Verify(
				"    ",
				" XXX",
				"XXX")
			.TransformsTo(
				"  X",
				"X  X",
				"X  X",
				" X");
		}

		[Test]
		public void Beacon()
		{
			Verify(
				"XX  ",
				"XX  ",
				"  XX",
				"  XX")
			.TransformsTo(
				"XX  ",
				"X   ",
				"   X",
				"  XX");
		}

		private static IEnumerable<ICell> Verify(params string[] pattern)
		{
			return PatternTestExtensions.Cells(pattern);
		}
	}
}