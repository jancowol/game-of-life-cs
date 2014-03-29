using System.Collections.Generic;

namespace gol
{
	public class FakeCell : ICell
	{
		private readonly int _liveNeighbourCount;

		public FakeCell(int liveNeighbourCount = 0)
		{
			_liveNeighbourCount = liveNeighbourCount;
		}

		public int LiveNeighbourCount(IEnumerable<ICell> cells)
		{
			return _liveNeighbourCount;
		}
	}
}