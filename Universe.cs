using System.Collections.Generic;

namespace gol
{
	public class Universe
	{
		public IEnumerable<Cell> LiveCells { get; private set; }

		public Universe() : this(new Cell[0])
		{
		}

		public Universe(IEnumerable<Cell> liveCells)
		{
			LiveCells = liveCells;
		}
	}
}