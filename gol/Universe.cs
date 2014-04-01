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
			var liveCells = new List<ICellLocation>();

			liveCells.AddRange(LiveCellsWithTwoOrThreeLiveNeighbours());
			liveCells.AddRange(DeadCellsWithThreeLiveNeighbours());

			return new Universe(liveCells);
		}

		public IEnumerable<ICellLocation> LiveCellLocations { get; private set; }

		public IEnumerable<ICellLocation> DeadCellLocations
		{
			get
			{
				return LiveCellLocations
					.SelectMany(liveCell => liveCell.Neighbours())
					.Except(LiveCellLocations)
					.Distinct();
			}
		}

		public int CellLiveNeighbourCount(ICellLocation cellLocation)
		{
			return cellLocation
				.Neighbours()
				.Intersect(LiveCellLocations)
				.Count();
		}

		private IEnumerable<ICellLocation> DeadCellsWithThreeLiveNeighbours()
		{
			return DeadCellLocations.Where(deadCell => CellLiveNeighbourCount(deadCell) == 3);
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