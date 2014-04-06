using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Universe : IUniverse
	{
		private readonly ICellLocationFilter[] _evolutionFilters;

		public Universe(IEnumerable<ICellLocation> liveCellPositions)
		{
			LiveCellLocations = liveCellPositions.ToArray();

			_evolutionFilters = new ICellLocationFilter[]
				{
					new LiveCellsWithTwoOrThreeLiveNeighboursFilter(this),
					new DeadCellsWithThreeLiveNeighboursFilter(this)
				};
		}

		public IUniverse Evolve()
		{
			return new Universe(FilterNextGenerationLiveCells());
		}

		private IEnumerable<ICellLocation> FilterNextGenerationLiveCells()
		{
			return _evolutionFilters.SelectMany(f => f.Filter());
		}

		public ICellLocation[] LiveCellLocations { get; private set; }

		public IEnumerable<ICellLocation> FindDeadCellLocations()
		{
			return LiveCellLocations
				.SelectMany(liveCell => liveCell.Neighbours())
				.Except(LiveCellLocations)
				.Distinct();
		}
	}
}