using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Universe : IUniverse
	{
		public Universe(IEnumerable<ICellLocation> liveCellPositions)
		{
			LiveCellLocations = liveCellPositions;
		}

		public IUniverse Evolve()
		{
			var nextGenerationCells =
				LiveCellsWithTwoOrThreeLiveNeighbours()
				.Concat(DeadCellsWithThreeLiveNeighbours());

			return new Universe(nextGenerationCells.ToArray());
		}

		public IEnumerable<ICellLocation> LiveCellLocations { get; private set; }

		private int CellLiveNeighbourCount(ICellLocation cellLocation)
		{
			return cellLocation
				.Neighbours()
				.Intersect(LiveCellLocations)
				.Count();
		}

		private IEnumerable<ICellLocation> FindDeadCellLocations()
		{
			return LiveCellLocations
				.SelectMany(liveCell => liveCell.Neighbours())
				.Except(LiveCellLocations)
				.Distinct();
		}

		private IEnumerable<ICellLocation> DeadCellsWithThreeLiveNeighbours()
		{
			return FindDeadCellLocations()
				.Where(deadCell =>
					CellLiveNeighbourCount(deadCell) == 3);
		}

		private IEnumerable<ICellLocation> LiveCellsWithTwoOrThreeLiveNeighbours()
		{
			return LiveCellLocations
				.Where(liveCell =>
					{
						var liveNeighbourCount = CellLiveNeighbourCount(liveCell);
						return liveNeighbourCount == 2 || liveNeighbourCount == 3;
					});
		}
	}
}