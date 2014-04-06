using System.Collections.Generic;

namespace gol
{
	public class LiveCellsWithTwoOrThreeLiveNeighboursFilter : ICellLocationFilter
	{
		public IEnumerable<ICellLocation> Filter(IUniverse universe)
		{
			return new CellsWithLiveNeighbourCountFilter(universe.LiveCellLocations, 2, 3)
				.Filter(universe.LiveCellLocations);
		}
	}
}