using System.Collections.Generic;

namespace gol
{
	public class FakeCell : ICell
	{
		private readonly int _liveNeighbourCount;

		public FakeCell(params ICell[] neighbourCells)
		{
			_liveNeighbourCount = neighbourCells.Length;
		}

		public FakeCell(int liveNeighbourCount)
		{
			_liveNeighbourCount = liveNeighbourCount;
		}

		public int LiveNeighbourCount(IEnumerable<ICell> cells)
		{
			return _liveNeighbourCount;
		}
	}
}