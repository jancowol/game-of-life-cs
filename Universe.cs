using System.Collections.Generic;

namespace gol
{
	public class Universe
	{
		public IEnumerable<ICell> LiveCells { get; private set; }

		public Universe() : this(new Cell[0])
		{
		}

		public Universe(IEnumerable<ICell> liveCells)
		{
			LiveCells = liveCells;
		}
	}
}