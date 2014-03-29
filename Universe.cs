using System.Collections.Generic;
using System.Linq;

namespace gol
{
	public class Universe
	{
		public IEnumerable<Cell> LiveCells { get; private set; }

		public Universe()
		{
			LiveCells = new Cell[0];
		}

		public Universe(IEnumerable<Cell> liveCells)
		{
			LiveCells = liveCells;
		}
	}
}