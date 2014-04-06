using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Universe : IUniverse
	{
		private readonly ICellLocationFilter[] _evolutionFilters;
		private ICellLocation[] _deadCellLocations;

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

		public ICellLocation[] DeadCellLocations
		{
			get
			{
				if (_deadCellLocations == null)
					_deadCellLocations =
						LiveCellLocations
							.SelectMany(liveCell => liveCell.Neighbours())
							.Except(LiveCellLocations)
							.Distinct()
							.ToArray();

				return _deadCellLocations;
			}
		}
	}
}