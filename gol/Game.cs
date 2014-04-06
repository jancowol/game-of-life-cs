using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Game
	{
		private readonly ICellLocationFilter[] _cellLocationFilters = new ICellLocationFilter[]
			{
				new LiveCellsWithTwoOrThreeLiveNeighboursFilter(),
				new DeadCellsWithThreeLiveNeighboursFilter()
			};

		public IUniverse Tick(IUniverse universe)
		{
			return new Universe(FilterNextGenerationLiveCells(universe));
		}

		public IEnumerable<ICellLocation> FilterNextGenerationLiveCells(IUniverse universe)
		{
			return _cellLocationFilters.SelectMany(f => f.Filter(universe));
		}
	}
}