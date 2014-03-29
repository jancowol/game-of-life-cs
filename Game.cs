using System.Collections.Generic;

namespace gol
{
	public class Game
	{
		public FakeUniverse Evolve(FakeUniverse universe)
		{
			var evolvedCells = new List<ICell>();

			evolvedCells.AddRange(CellsWithTwoOrThreeLiveNeighbours(universe));
			evolvedCells.AddRange(DeadCellsToMakeAlive(universe));

			return new FakeUniverse(evolvedCells);
		}

		private static IEnumerable<ICell> DeadCellsToMakeAlive(IUniverse universe)
		{
			foreach (var deadCell in universe.DeadCells)
			{
				if (deadCell.LiveNeighbourCount(universe.LiveCells) == 3)
				{
					yield return deadCell;
				}
			}
		}

		private static IEnumerable<ICell> CellsWithTwoOrThreeLiveNeighbours(IUniverse universe)
		{
			foreach (var liveCell in universe.LiveCells)
			{
				var liveNeighbourCount = liveCell.LiveNeighbourCount(universe.LiveCells);
				if (liveNeighbourCount == 2 || liveNeighbourCount == 3)
				{
					yield return liveCell;
				}
			}
		}
	}
}