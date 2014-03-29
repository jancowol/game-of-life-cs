using System.Collections.Generic;

namespace gol
{
	public class FakeUniverse : IUniverse
	{
		public IEnumerable<ICell> LiveCells { get; private set; }

		public FakeUniverse() : this(new ICell[0])
		{
		}

		public FakeUniverse(IEnumerable<ICell> liveCells)
		{
			LiveCells = liveCells;
		}
	}
}