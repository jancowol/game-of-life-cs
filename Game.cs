using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Game
	{
		public IUniverse Evolve(IUniverse universe)
		{
			var liveCells = new List<ICellLocation>();

			liveCells.AddRange(LiveCellsWithTwoOrThreeLiveNeighbours(universe));
			liveCells.AddRange(DeadCellsWithThreeLiveNeighbours(universe));

			return new Universe(liveCells);
		}

		private static IEnumerable<ICellLocation> DeadCellsWithThreeLiveNeighbours(IUniverse universe)
		{
			return universe.DeadCellLocations
				.Where(deadCell => universe.CellLiveNeighbourCount(deadCell) == 3);
		}

		private static IEnumerable<ICellLocation> LiveCellsWithTwoOrThreeLiveNeighbours(IUniverse universe)
		{
			return universe.LiveCellLocations
				.Where(liveCell =>
					{
						var liveNeighbourCount = universe.CellLiveNeighbourCount(liveCell);
						return liveNeighbourCount == 2 || liveNeighbourCount == 3;
					});
		}
	}
}