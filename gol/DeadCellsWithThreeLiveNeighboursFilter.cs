using System.Collections.Generic;

namespace gol
{
	public class DeadCellsWithThreeLiveNeighboursFilter : ICellLocationFilter
	{
		private readonly IUniverse _universe;

		public DeadCellsWithThreeLiveNeighboursFilter(IUniverse universe)
		{
			_universe = universe;
		}

		public IEnumerable<ICellLocation> Filter()
		{
			return new CellsWithLiveNeighbourCountFilter(_universe.LiveCellLocations, 3)
				.Filter(_universe.DeadCellLocations);
		}
	}
}