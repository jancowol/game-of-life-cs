using System.Collections.Generic;

namespace gol
{
	public class FakeUniverse : IUniverse
	{
		public IEnumerable<ICell> LiveCells { get; private set; }
		public IEnumerable<ICell> DeadCells { get; set; }

		public FakeUniverse() : this(new ICell[0])
		{
		}

		public FakeUniverse(IEnumerable<ICell> liveCells)
		{
			LiveCells = liveCells;
			DeadCells = new ICell[0];
		}

		public FakeUniverse(IEnumerable<ICell> liveCells, IEnumerable<ICell> deadCells)
		{
			LiveCells = liveCells;
			DeadCells = deadCells;
		}
	}
}