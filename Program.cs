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

			IUniverse universe = new Universe(Glider());

			var game = new Game();

			while (true)
			{
				RenderUniverse(universe);
				universe = game.Evolve(universe);
				Thread.Sleep(200);
			}
		}

		private static IEnumerable<ICell> Glider()
		{
			return Cells(
				"X X",
				" XX",
				" X ");
		}

		private static IEnumerable<ICell> Blinker()
		{
			return Cells(
				" X ",
				" X ",
				" X ");
		}

		private static void RenderUniverse(IUniverse universe)
		{
			Console.Clear();
			foreach (var cell in universe.LiveCells.Cast<Cell>())
			{
				Console.SetCursorPosition(cell.X, cell.Y);
				Console.Write("X");
			}
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