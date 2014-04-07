using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class CellsWithLiveNeighbourCountFilter
	{
		private readonly IEnumerable<ICellLocation> _liveCellLocations;
		private readonly int[] _filterNeighbourCounts;

		public CellsWithLiveNeighbourCountFilter(IEnumerable<ICellLocation> liveCellLocations, params int[] liveNeighbourCounts)
		{
			_liveCellLocations = liveCellLocations;
			_filterNeighbourCounts = liveNeighbourCounts;
		}

		public IEnumerable<ICellLocation> Filter(IEnumerable<ICellLocation> cellLocations)
		{
			return cellLocations
				.Where(LiveNeighbourCountInCountFilters);
		}

		private bool LiveNeighbourCountInCountFilters(ICellLocation cellLocation)
		{
			return _filterNeighbourCounts
				.Contains(cellLocation.CountOfNeighboursIn(_liveCellLocations));
		}
	}
}