using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Universe : IUniverse
	{
		public Universe(IEnumerable<ICell> liveCells)
		{
			LiveCells = liveCells;
		}

		public IEnumerable<ICell> LiveCells { get; private set; }

		public IEnumerable<ICell> DeadCells
		{
			get
			{
				return LiveCells
					.SelectMany(liveCell => liveCell.AdjacentCells())
					.Except(LiveCells)
					.Distinct();
			}
		}

	}
}