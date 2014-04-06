using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Universe : IUniverse
	{
		private ICellLocation[] _deadCellLocations;

		public Universe(IEnumerable<ICellLocation> liveCellPositions)
		{
			LiveCellLocations = liveCellPositions.ToArray();
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