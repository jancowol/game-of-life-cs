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
			return new[]
				{
					new Cell(0, 0), new Cell(2, 0), new Cell(1, 1), new Cell(2, 1), new Cell(1, 2)
				};
		}

		private static IEnumerable<ICell> Blinker()
		{
			return new[]
				{
					new Cell(0, 1), new Cell(1, 1), new Cell(2, 1)
				};
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
	}
}