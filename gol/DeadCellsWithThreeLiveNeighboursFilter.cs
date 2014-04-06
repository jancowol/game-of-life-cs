using System.Collections.Generic;

namespace gol
{
	public class DeadCellsWithThreeLiveNeighboursFilter : ICellLocationFilter
	{
		public IEnumerable<ICellLocation> Filter(IUniverse universe)
		{
			return new CellsWithLiveNeighbourCountFilter(universe.LiveCellLocations, 3)
				.Filter(universe.DeadCellLocations);
		}
	}
}