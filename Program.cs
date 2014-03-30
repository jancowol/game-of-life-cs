using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace gol
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			Console.SetWindowSize(120, 80);

			var universe = SeedUniverse(
				Blinker().AtPosition(20, 10),
				Blinker().AtPosition(93, 10),
				Blinker().AtPosition(20, 43),
				Blinker().AtPosition(93, 43),
				GliderSE().AtPosition(35, 10),
				WeirdGrowingThingy().AtPosition(50, 40),
				Pulsar().AtPosition(50, 20));

			var game = new Game();

			while (true)
			{
				RenderUniverse(universe);
				universe = game.Evolve(universe);
				Thread.Sleep(100);
			}
		}

		private static IUniverse SeedUniverse(params IEnumerable<ICellLocation>[] patterns)
		{
			return new Universe(patterns.SelectMany(p => p));
		}

		private static IEnumerable<ICellLocation> AtPosition(this IEnumerable<ICellLocation> pattern, int x, int y)
		{
			return pattern
				.Cast<XYCellLocation>()
				.Select(cell =>
					new XYCellLocation(cell.X + x, cell.Y + y)).ToList();
		}

		private static IEnumerable<ICellLocation> GliderSE()
		{
			return Cells(
				"X X",
				" XX",
				" X ");
		}

		private static IEnumerable<ICellLocation> GliderNE()
		{
			return Cells(
				"XX ",
				" XX",
				"X  ");
		}

		private static IEnumerable<ICellLocation> Blinker()
		{
			return Cells(
				" X ",
				" X ",
				" X ");
		}

		private static IEnumerable<ICellLocation> Pulsar()
		{
			return Cells(
				"  XXX   XXX  ",
				"             ",
				"X    X X    X",
				"X    X X    X",
				"X    X X    X",
				"  XXX   XXX  ",
				"             ",
				"  XXX   XXX  ",
				"X    X X    X",
				"X    X X    X",
				"X    X X    X",
				"             ",
				"  XXX   XXX  ");
		}

		private static IEnumerable<ICellLocation> WeirdGrowingThingy()
		{
			return Cells(
				"XX ",
				" XX",
				"XX ");
		}

		private static void RenderUniverse(IUniverse universe)
		{
			Console.Clear();
			foreach (var cell in universe.LiveCellLocations.Cast<XYCellLocation>())
			{
				Console.SetCursorPosition(cell.X, cell.Y);
				Console.Write("O");
			}
		}

		public static IEnumerable<ICellLocation> Cells(params string[] pattern)
		{
			for (int y = 0; y < pattern.Length; y++)
			{
				var line = pattern[y];
				for (int x = 0; x < line.Length; x++)
					if (line[x] != ' ')
						yield return new XYCellLocation(x, y);
			}
		}
	}
}