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
	}
}